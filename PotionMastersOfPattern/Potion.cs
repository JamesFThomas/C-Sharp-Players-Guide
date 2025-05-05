using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotionMastersOfPattern
{
    internal class Potion
    {
        public PotionType _Type { get; set; } = PotionType.Water;

        public Potion() { }

        
        public string TypeToString()
        {
            switch (_Type)
            {
                case PotionType.Water:
                    return "Water";
                case PotionType.Elixir:
                    return "Elixir";
                case PotionType.Poison:
                    return "Poison Potion";
                case PotionType.Invisibility:
                    return "Invisibility Potion";
                case PotionType.NightVision:
                    return "Night Vision Potion";
                case PotionType.CloudyBrew:
                    return "Cloudy Brew";
                case PotionType.Wraith:
                    return "Wraith Potion";
                case PotionType.Ruined:
                    return "Ruined";
                default:
                    return _Type.ToString();
            }
        }

        public void AddIngredient(IngredientType ingredient)
        {
            /*
        * Potion Patterns 

        - All potions start as water.

       - Adding stardust to water turns it into an elixir. 

       - Adding snake venom to elixir turns into into poison potion. 

       - Adding shadow glass to an elixir turns into a invisibility potion.  

       - Adding eyeshine gem to an elixir turns into a night vision potion.  

       - Adding shadow glass to a night visibility potion turns it into a cloudy brew.  

       - Adding eyeshine gem to a invisibility potion turns it into into a cloudy brew.

       - Adding stardust to an elixir turns into a wraith potion.

       - Anything else results in a ruined potion.

        */

            // use positional pattern matching to update _Type field
            switch ((ingredient , _Type ))
            {
                case ( IngredientType.stardust, PotionType.Water):
                    _Type = PotionType.Elixir;
                    break;
                case (IngredientType.snakeVenom, PotionType.Elixir):
                    _Type = PotionType.Poison;
                    break;
                case (IngredientType.shadowGlass, PotionType.Elixir):
                    _Type = PotionType.Invisibility;
                    break;
                case (IngredientType.eyeshineGem, PotionType.Elixir):
                    _Type = PotionType.NightVision;
                    break;
                case (IngredientType.shadowGlass, PotionType.NightVision):
                    _Type = PotionType.CloudyBrew;
                    break;
                case (IngredientType.eyeshineGem, PotionType.Invisibility):
                    _Type = PotionType.CloudyBrew;
                    break;
                case (IngredientType.stardust, PotionType.Elixir):
                    _Type = PotionType.Wraith;
                    break;
                case (_, _):
                    _Type = PotionType.Ruined;
                    break;
            }

        }

    }



    public enum IngredientType
    {
        stardust = 1,
        snakeVenom,
        shadowGlass,
        eyeshineGem,
    }

    public enum PotionType
    {
        Water = 1,
        Elixir,
        Poison,
        Invisibility,
        NightVision,
        CloudyBrew,
        Wraith,
        Ruined
    }

    
}
