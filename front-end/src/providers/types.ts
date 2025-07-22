// Shared user types for providers

export interface IUser {
  id?: string;
  name?: string;
  surname?: string;
  userName?: string;
  email?: string;
}

export interface IInstructor extends IUser {
  bio?: string;
  profession?: string;
}

export interface IStudent extends IUser {
  academicLevel?: string;
  interests?: string;
}
