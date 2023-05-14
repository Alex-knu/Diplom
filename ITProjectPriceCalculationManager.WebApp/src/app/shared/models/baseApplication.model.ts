import { BaseModel } from "./base.model";

export class BaseApplication extends BaseModel {

  constructor(id: number | null = null) {
    super(id);
  }

  name: string;
  description: string;
  status: string;
  price: number | null;
  profit: number;
}
