export interface VechilceModel {
  id: number,
  jSN: string,
  vechilceModel: string
}

export interface ShopModel {
  shopId: number,
  name: string
}

export interface MeasurementPointModel {
  measurementPointId: number,
  name: string
}

export interface MeasurementModel {
  id: number,
  vechicle: VechilceModel,
  shop: ShopModel,
  measurementPoint: MeasurementPointModel,
  date: Date,
  gap: number | null,
  flush: number | null,
}
