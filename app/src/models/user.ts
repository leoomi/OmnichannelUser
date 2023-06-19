import { Address } from "./address";

export interface User {
  id?: number;
  name?: string;
  email?: string;
  phoneNumber?: string;
  address?: Address;
  dateOfBirth?: Date;
}