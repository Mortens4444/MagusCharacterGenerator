using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace M.A.G.U.S.Enums;

public enum Alignment
{
    [Description("None")]
    None,

    [Description("Neutral")]
    Neutral,

    [Description("Animal")]
    Animal,

    [Description("Life")]
    [Display(Name = "Unicorn")]
    Life,

    [Description("Death")]
    [Display(Name = "Manticore")]
    Death,

    [Description("Chaos")]
    [Display(Name = "Traclon")]
    Chaos,

    [Description("Order")]
    [Display(Name = "Draco")]
    Order,

    [Description("Chaos, life")]
    [Display(Name = "Pegasus")]
    ChaosLife,

    [Description("Order, life")]
    [Display(Name = "Griffin")]
    OrderLife,

    [Description("Chaos, death")]
    [Display(Name = "Demon")]
    ChaosDeath,

    [Description("Order, death")]
    [Display(Name = "Hastin")]
    OrderDeath,

    [Description("Life, chaos")]
    [Display(Name = "Mermaid")]
    LifeChaos,

    [Description("Life, order")]
    [Display(Name = "Cherub")]
    LifeOrder,

    [Description("Death, chaos")]
    [Display(Name = "Chimera")]
    DeathChaos,

    [Description("Death, order")]
    [Display(Name = "Kraken")]
    DeathOrder,

    [Description("Various")]
    Various
}
