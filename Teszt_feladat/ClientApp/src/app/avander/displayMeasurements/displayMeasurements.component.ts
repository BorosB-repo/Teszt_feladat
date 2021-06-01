import { AfterViewInit, ChangeDetectionStrategy, Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Observable, of } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { MeasurementModel, ShopModel } from '../../shared/models';
import { HttpService } from '../../shared/services/http.service';
import { MeasurementDetailsDialog } from './measurement-details-dialog/measurement-details-dialog.component';

@Component({
  selector: 'displayMeasurements',
  templateUrl: './displayMeasurements.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class DisplayMeasurementsComponent implements OnInit, AfterViewInit {
  allMeasurementsQuery: Array<MeasurementModel> = new Array<MeasurementModel>();
  filteredMeasurements: MatTableDataSource<MeasurementModel> = new MatTableDataSource<MeasurementModel>();
  displayedColumns: Array<string> = ['jsn', 'vechicleModel', 'shopName', 'measurementPointName', 'date', 'gap', 'flush', 'details'];

  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator | undefined;

  filters: FormGroup;
  shopFilterOptions: Observable<Array<ShopModel>> = of([]);
  constructor(private readonly http: HttpService,
    private readonly fb: FormBuilder,
    private readonly dialog: MatDialog) {
    this.filters = fb.group({
      jsn: [''],
      shop: [''],
      interval: this.fb.group({
        start: [null],
        end: [null]
      })
    });
  }

  ngOnInit(): void {
    this.init();
  }

  init(): void {
    this.http.getAllMeasurements().subscribe(measurements => {
      this.allMeasurementsQuery = measurements;
      this.shopFilterOptions = this.generateShopFilterOptions();
      this.filters.valueChanges.subscribe(x => {

      });
      this.filters.valueChanges.pipe(startWith(this.filters.value), map(values => {
        let endDate: Date = new Date(values.interval.end);
        endDate.setDate(endDate.getDate() + 1);

        let filteredMeasurements = this.allMeasurementsQuery.filter(measurement =>
          (values.jsn === '' ? true : measurement.vechicle.jsn.includes(values.jsn))
          && (values.shop === '' ? true : measurement.shop.shopId === values.shop)
          && (values.interval.start === null ? true : new Date(measurement.date) >= values.interval.start)
          && (values.interval.end === null ? true : new Date(measurement.date) <= endDate)
        )
        let newDataSource = new MatTableDataSource(filteredMeasurements);
        if (this.paginator)
          newDataSource.paginator = this.paginator;
        return newDataSource
      })).subscribe(dataSource => {
        this.filteredMeasurements = dataSource;
      });
    });

  }

  generateShopFilterOptions(): Observable<Array<ShopModel>> {
    let filterOptions: Array<ShopModel> = [];
    this.allMeasurementsQuery.map(x => x.shop).forEach(shop => {
      if (!filterOptions.map(x => x.shopId).includes(shop.shopId))
        filterOptions.push(shop);
    });
    return of(filterOptions);
  }

  ngAfterViewInit(): void {
    if (this.paginator)
      this.filteredMeasurements.paginator = this.paginator;
  }

  onDetailsClick(model: MeasurementModel): void {
    this.dialog.open(MeasurementDetailsDialog, {
      data: model,
      autoFocus: false,
      disableClose: true,
      minWidth: '30%'
    });
  }
}
