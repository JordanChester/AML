import { Branch } from "../_models/Branch";

export class UpdateBranchRequest {
  public email: string | undefined;
  public branch: Branch | undefined;
}
