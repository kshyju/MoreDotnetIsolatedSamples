using Microsoft.Azure.Functions.Worker.Converters;
using Net8SimpleHttpTrigger;

namespace MyCompany.Functions.Converters
{
    public sealed class MyTypeEnumConverter : IInputConverter
    {
        public ValueTask<ConversionResult> ConvertAsync(ConverterContext context)
        {
            var typeEnumValue = TypeEnum.Unknown;
            if (context.FunctionContext.BindingContext.BindingData.TryGetValue("type", out var idObj))
            {
                try
                {
                    if (string.Equals(idObj.ToString(), "A", StringComparison.OrdinalIgnoreCase))
                    {
                        typeEnumValue = TypeEnum.TypeA;
                    }
                    else if (string.Equals(idObj.ToString(), "B", StringComparison.OrdinalIgnoreCase))
                    {
                        typeEnumValue = TypeEnum.TypeB;
                    }
                }
                catch (Exception ex)
                {
                    return new ValueTask<ConversionResult>(ConversionResult.Failed(ex));
                }
            }

            return new ValueTask<ConversionResult>(ConversionResult.Success(typeEnumValue));
        }
    }
}
