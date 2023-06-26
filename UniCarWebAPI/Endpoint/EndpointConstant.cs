namespace UniCar.Endpoint;

public static  class EndpointConstant
{
    private const string RootEndpoint = "/api";

    public static  class Car
    {
        public const string CarBrandEndpoint = RootEndpoint + "/carBrand";
        public const string CarTypeEndpoint = RootEndpoint + "/carType";
    }
}