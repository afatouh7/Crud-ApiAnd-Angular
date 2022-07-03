export interface IPerson{
  data: Data[]
  success: boolean
  message: any
}

export interface Data {
  id: number
  name: string
  age: number
  address: Address
}

export interface Address {
  id: number
  street: string
  city: string
  country: string
}
