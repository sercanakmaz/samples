namespace Serene.Sample1.BasicSamples {
    export interface CustomerGrossSalesListRequest extends Serenity.ListRequest {
        StartDate?: string;
        EndDate?: string;
    }
}

