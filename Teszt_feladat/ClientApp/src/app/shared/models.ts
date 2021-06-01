export interface VechicleModel {
  id: number,
  jsn: string,
  model: string
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
  vechicle: VechicleModel,
  shop: ShopModel,
  measurementPoint: MeasurementPointModel,
  date: Date,
  gap: number | null,
  flush: number | null,
}

export interface ApiResult {
  isSuccess: boolean,
  message: string
}
