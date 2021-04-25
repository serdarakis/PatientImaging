import { Doctor } from "./doctor";

export interface Patient {
  identityNumber: string;
  polyclinicCode: string,
  doctor: Doctor,
  dateOfBirth: string,
  gender: number,
  phoneNumber: string,
  visitDate: string,
  nextVisitDate: string,
  doctorNote: string,

}
