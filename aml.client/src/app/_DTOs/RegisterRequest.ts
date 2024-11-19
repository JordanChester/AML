import { AccountType } from "../_classes/AccountType";

export class RegisterRequest {
  public email: string | undefined;
  public password: string | undefined;
  public accountType: AccountType = 1;
  public name: string | undefined;
  public address: string | undefined;
  public phone: string | undefined;
}
