using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeKioskSystem
{
    /* Promotion interface defines that a promotion must reduce a price based on requirements
     * these requirements are typically based on the quantity of an item in a cart
     */
    public interface Promotion
    {
        double getDiscount(int amount);
        Boolean meetsRequirements(int amount);
    }

    public enum PromotionType
    {
        Sale,
        Group,
        Additional
    }
    
    //Promotion factory to house type code functionality
    public class PromotionFactory
    {
        public Promotion createPromotion(String[] promotionArgs)
        {
            switch ((PromotionType) Enum.Parse(typeof(PromotionType), promotionArgs[0]))
            {
                case PromotionType.Sale:
                    return new SalePromotion(promotionArgs);
                case PromotionType.Group:
                    return new GroupPromotion(promotionArgs);
                case PromotionType.Additional:
                    return new AdditionalPromotion(promotionArgs);
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
