import { AccountType } from "../_classes/AccountType";
import { Branch } from "../_models/Branch";

export class RegisterRequest {
  public email: string | undefined;
  public password: string | undefined;
  public accountType: AccountType = 1;
  public name: string | undefined;
  public address: string | undefined;
  public phone: string | undefined;
  public branch: Branch | undefined;
}
