using GenericRazorHelpers.SxaModels.Generic;

namespace GenericRazorHelpers.SxaModels
{
    public class Promo : BaseModel
    {
        public const string VARIANT_WITH_TEXT = "WithText";
        public ImageField? PromoIcon { get; set; }
        public TextField? PromoText { get; set; }
        public HyperLinkField? PromoLink { get; set; }
    }
}
