using M.A.G.U.S.Things;
using M.A.G.U.S.Things.Animals;
using M.A.G.U.S.Things.Clothes;
using M.A.G.U.S.Things.Food;
using M.A.G.U.S.Things.Gemstones;
using M.A.G.U.S.Things.MagicalObjects;
using M.A.G.U.S.Things.Other;
using M.A.G.U.S.Things.Shields;
using M.A.G.U.S.Things.Trappings;
using System.Reflection;


namespace M.A.G.U.S.Utils;

public static class Scale
{
    private static readonly Dictionary<Type, double> Weights = new Dictionary<Type, double>
    {
        // ==============================================================================
        // --- Clothes (kg) ---
        // ==============================================================================
        { typeof(Belt), 0.5 },
        { typeof(WaistBelt), 0.3 },
        { typeof(Stockings), 0.2 },
        { typeof(PeasantShirt), 0.3 },
        { typeof(NobleShirt), 0.5 },
        { typeof(Pants), 0.5 },
        { typeof(Pantaloons), 0.4 },
        { typeof(Trousers), 0.6 },
        { typeof(Caftan), 0.8 },
        { typeof(Tunic), 0.4 },
        { typeof(Vest), 0.3 },
        { typeof(Coat), 1.5 },
        { typeof(Hood), 0.2 },
        { typeof(Cap), 0.1 },
        { typeof(Hat), 0.3 },
        { typeof(CapeFabric), 1.0 },
        { typeof(CapeFur), 2.5 },
        { typeof(CapeSilk), 0.5 },
        { typeof(Chiffon), 0.1 },
        { typeof(Toga), 1.2 },
        { typeof(Sandals), 0.5 },
        { typeof(Slippers), 0.4 },
        { typeof(Shoes), 1.0 },
        { typeof(Boots), 1.5 },
        { typeof(BootsWalking), 1.8 },
        { typeof(BootsRiding), 2.0 },
        { typeof(GlovesNoble), 0.1 },
        { typeof(GlovesFencing), 0.2 },
        { typeof(Saru), 0.5 },


        // ==============================================================================
        // --- Food (kg) ---
        // ==============================================================================
        { typeof(LunchDinner), 0.5 }, // Egy adag étel
        { typeof(MeatPortion), 0.3 },
        { typeof(FishPortion), 0.2 },
        { typeof(GameMeatPortion), 0.4 },
        { typeof(Vegetables), 0.3 },
        { typeof(Cheese), 0.8 },
        { typeof(ButterKilo), 1.0 }, // Feltételezve, hogy 1 kg
        { typeof(SaltBlock), 1.0 },
        { typeof(HoneyJar), 0.5 },
        { typeof(EggsDozen), 0.7 }, // 12 tojás
        
        { typeof(CommonSpice), 0.1 },
        { typeof(RareSpice), 0.1 },
        { typeof(SpecialSpice), 0.1 },

        { typeof(BeerMug), 0.5 }, // 1 Korsó sör (folyadékkal)
        { typeof(WineCup), 0.2 }, // 1 Pohár bor (folyadékkal)
        { typeof(BrandyGlass), 0.1 }, // 1 Pohár brandy (folyadékkal)
        { typeof(Liqueur), 0.5 }, // Egy üveg
        { typeof(MilkJug), 1.0 }, // 1 kancsó tej (folyadékkal)
        { typeof(SugarGlass), 0.1 },
        { typeof(Loree), 0.5 }, // Egy adag Loree (ital/étel)
        
        // Borok (üveggel együtt)
        { typeof(OldWineFromPredoc1Cluster), 1.5 },
        { typeof(OldWineFromPredoc2Clusters), 1.5 },
        { typeof(OldWineFromPredoc3Clusters), 1.5 },
        { typeof(OldWineFromPredoc4Clusters), 1.5 },
        { typeof(OldWineFromPredoc5Clusters), 1.5 },

        { typeof(FodderOneDay), 5.0 }, // Állattakarmány egy napra


        // ==============================================================================
        // --- Animals (kg) ---
        // (Ezek valószínűleg csak a vételárat jelölik, nem a hordozható súlyt, de itt vannak a reális, átlagos felnőtt súlyok)
        // ==============================================================================
        { typeof(Cat), 4.0 },
        { typeof(DogGuard), 30.0 },
        { typeof(DogHunting), 25.0 },
        { typeof(DogSled), 35.0 },
        { typeof(DogWar), 40.0 },

        { typeof(Hen), 2.0 },
        { typeof(Chicken), 1.5 },
        { typeof(Goose), 5.0 },
        { typeof(Turkey), 8.0 },

        { typeof(Calf), 150.0 },
        { typeof(Cow), 700.0 },
        { typeof(Pig), 150.0 },
        { typeof(Sheep), 70.0 },
        { typeof(Goat), 60.0 },
        { typeof(Ox), 1000.0 },

        { typeof(Donkey), 200.0 },
        { typeof(Mule), 350.0 },
        { typeof(Camel), 600.0 },

        { typeof(HorsePony), 250.0 },
        { typeof(HorseDraft), 400.0 },
        { typeof(HorseTraveler), 500.0 },
        { typeof(HorseLightWar), 600.0 },
        { typeof(HorseHeavyWar), 800.0 },

        { typeof(FalconHunting), 1.5 }, // Sólyom


        // ==============================================================================
        // --- Gemstones (kg) ---
        // (Ezek nagyon kicsik, ezért grammokban adom meg őket. 0.001 kg = 1 gramm)
        // (A MAGUS-ban gyakran használt 1 karát kb. 0.2 gramm)
        // ==============================================================================
        { typeof(Agate), 0.005 },
        { typeof(Alexandrite), 0.001 },
        { typeof(Amber), 0.002 },
        { typeof(Amethyst), 0.003 },
        { typeof(Aquamarine), 0.004 },
        { typeof(Azurite), 0.002 },
        { typeof(BlackOpal), 0.001 },
        { typeof(Carnelian), 0.003 },
        { typeof(Chalcedony), 0.004 },
        { typeof(Chrysoberyl), 0.001 },
        { typeof(Chrysoprase), 0.003 },
        { typeof(Coral), 0.005 },
        { typeof(Diamond), 0.0005 }, // 2.5 karátos gyémánt kb. 0.5 gramm
        { typeof(Emerald), 0.0008 },
        { typeof(Garnet), 0.0015 },
        { typeof(Hematite), 0.005 },
        { typeof(Jade), 0.006 },
        { typeof(Jasper), 0.004 },
        { typeof(Jet), 0.002 },
        { typeof(LapisLazuli), 0.003 },
        { typeof(Malachite), 0.004 },
        { typeof(Moonstone), 0.0015 },
        { typeof(Nephrite), 0.005 },
        { typeof(Obsidian), 0.005 },
        { typeof(Onyx), 0.003 },
        { typeof(Opal), 0.001 },
        { typeof(Pearl), 0.0005 },
        { typeof(Peridot), 0.001 },
        { typeof(RockCrystal), 0.005 },
        { typeof(RoseQuartz), 0.004 },
        { typeof(Ruby), 0.0008 },
        { typeof(Sapphire), 0.001 },
        { typeof(Serpentine), 0.005 },
        { typeof(SmokyQuartz), 0.004 },
        { typeof(Spinel), 0.001 },
        { typeof(TigersEye), 0.003 },
        { typeof(Topaz), 0.0015 },
        { typeof(Tourmaline), 0.001 },
        { typeof(Turquoise), 0.002 },
        { typeof(Zircon), 0.001 },
        
        // Amulets & Medallions (könnyű ékszer)
        { typeof(AmuletAgainstPoisons120Mp), 0.05 },
        { typeof(AmuletAgainstPoisons40Mp), 0.05 },
        { typeof(AmuletAgainstPoisons65Mp), 0.05 },
        { typeof(AmuletAgainstPoisons95Mp), 0.05 },
        { typeof(AmuletOfInvisibility), 0.05 },
        { typeof(AmuletOfLuck), 0.05 },
        { typeof(AmuletOfMindProtection), 0.05 },
        { typeof(AmuletOfPower), 0.05 },
        { typeof(AmuletOfTruth), 0.05 },
        { typeof(MedallionOfBalance), 0.05 },
        { typeof(MedallionOfSteelyWill), 0.05 },

        // Boots & Cloaks (hasonló a normál ruházathoz)
        { typeof(BootsOfLeaping), 1.5 },
        { typeof(BootsOfRushing), 1.5 },
        { typeof(StealthFootwear), 1.0 },
        { typeof(ProtectiveCloak123Mp), 1.0 }, // Textil palást
        { typeof(ProtectiveCloak153Mp), 1.0 },
        { typeof(ProtectiveCloak63Mp), 1.0 },
        { typeof(ProtectiveCloak93Mp), 1.0 },
        { typeof(CloakOfInvisibility), 1.0 },
        { typeof(WarmCoat), 2.0 }, // Meleg kabát

        // Staffs (botok, súlyuk mint egy harci bot vagy vándorbot)
        { typeof(WeaponStaff), 2.0 }, // fegyver bot
        { typeof(DragonStaff), 2.5 },
        { typeof(SerpentStaff), 2.5 },
        { typeof(WanderersStaff), 1.5 },
        { typeof(StaffOfFriendship), 1.5 },
        { typeof(StaffOfLight), 1.5 },
        { typeof(StaffOfNecromancers), 1.5 },
        { typeof(StaffOfSpellbreaking), 1.5 },
        { typeof(StaffOfTelekinesis), 1.5 },
        { typeof(StaffOfTerror), 1.5 },
        { typeof(StaffOfTransformation), 1.5 },
        
        // Wand, Scroll, Seeker
        { typeof(WandOfIllusion), 0.3 },
        { typeof(WandOfTravel), 0.3 },
        { typeof(MagicScroll), 0.01 }, // Nagyon könnyű
        { typeof(Seeker), 0.5 }, // Kisebb eszköz

        // Potions & Drinks (kb. egy adag folyadék a kis üvegben)
        { typeof(HealingPotionHp), 0.3 },
        { typeof(HealingPotionPrp), 0.3 },
        { typeof(PotionOfCourage), 0.3 },
        { typeof(PotionOfDragonsBreath120Mp), 0.3 },
        { typeof(PotionOfDragonsBreath60Mp), 0.3 },
        { typeof(PotionOfDragonsBreath90Mp), 0.3 },
        { typeof(PotionOfFlight), 0.3 },
        { typeof(PotionOfInvisibility), 0.3 },
        { typeof(PotionOfInvulnerability), 0.3 },
        { typeof(PotionOfMentalFreshness), 0.3 },
        { typeof(PotionOfMindReading), 0.3 },
        { typeof(PotionOfPower), 0.3 },
        { typeof(PotionOfShrinking), 0.3 },
        { typeof(PotionOfTransformationEventual), 0.3 },
        { typeof(PotionOfTransformationTemporary), 0.3 },
        { typeof(PotionOfWillTransfer), 0.3 },
        { typeof(LovePotion), 0.3 },
        { typeof(DrinkOfTheGods10Mp), 0.3 },
        { typeof(DrinkOfTheGods130Mp), 0.3 },
        { typeof(DrinkOfTheGods20Mp), 0.3 },
        { typeof(DrinkOfTheGods40Mp), 0.3 },
        { typeof(DrinkOfTheGods80Mp), 0.3 },
        { typeof(WaterOfLife), 0.3 },

        // Egyéb varázstárgyak
        { typeof(BannerOfHeroes), 3.0 }, // Zászló rúdastul
        { typeof(BottomlessJug), 1.5 }, // Kancsó, üresen
        { typeof(ClimbingGloves), 0.5 }, // Kesztyű
        { typeof(DeepPouch), 0.1 }, // Üres zacskó
        { typeof(FireBow), 1.0 }, // Íj, az íjakhoz hasonlóan
        { typeof(FlyingCarpet), 5.0 }, // Összecsomagolva
        { typeof(GlovesOfNimbleFingers), 0.1 },
        { typeof(GlovesOfStrength), 0.2 },
        { typeof(HelmetOfTongues), 2.0 }, // Sisak súlya
        
        // Rúna tárgyak (közepes/könnyű páncél és kard)
        { typeof(RuneArmor123Mp), 12.0 }, // Könnyebb páncélzat
        { typeof(RuneArmor153Mp), 12.0 },
        { typeof(RuneArmor63Mp), 12.0 },
        { typeof(RuneArmor93Mp), 12.0 },
        { typeof(RuneSword123Mp), 1.5 }, // Kard
        { typeof(RuneSword153Mp), 1.5 },
        { typeof(RuneSword63Mp), 1.5 },
        { typeof(RuneSword93Mp), 1.5 },

        // ==============================================================================
        // --- Other (kg) ---
        // ==============================================================================
        { typeof(BackpackSmall), 0.5 },
        { typeof(BackpackLarge), 1.0 },
        { typeof(BarrelSmall), 5.0 }, // Üresen
        { typeof(BarrelLarge), 15.0 }, // Üresen
        { typeof(Basket), 0.5 },
        { typeof(Bell), 0.5 },
        { typeof(BeltHolster), 0.1 },
        { typeof(Blanket), 1.0 },
        { typeof(Bucket), 1.0 },
        { typeof(Candle), 0.05 },
        { typeof(CastIronFootedBowl), 1.5 },
        { typeof(ChainMeter), 1.0 }, // Méterenként
        { typeof(Chalk), 0.01 },
        { typeof(ChestSmall), 8.0 }, // Üresen
        { typeof(ChestLarge), 25.0 }, // Üresen
        { typeof(Climbingirons), 1.0 },
        { typeof(DaggerSleeve), 0.1 },
        { typeof(Deadboltpadlock), 0.5 },
        { typeof(Earthenware), 0.5 },
        { typeof(FabricEll), 0.1 }, // Egy rőf szövet
        { typeof(FireSteel), 0.1 },
        { typeof(FishHook), 0.01 },
        { typeof(FishingNet), 2.0 },
        { typeof(Flask), 0.2 }, // Üresen
        { typeof(FlintAndSteel), 0.1 },
        { typeof(Fur), 1.0 }, // Bőrkötél
        { typeof(Hammer), 1.0 },
        { typeof(Hatchet), 1.5 },
        { typeof(Ink), 0.1 }, // Üvegcsében
        { typeof(Ladder), 8.0 }, // Létra (pl. 3-4 méter)
        { typeof(Lampion), 0.5 },
        { typeof(Lantern), 0.8 },
        { typeof(MirrorMetal), 0.5 },
        { typeof(NailDozen), 0.2 },
        { typeof(Oilcloth), 0.5 },
        { typeof(OilForLamps), 1.0 }, // Liternyi olaj
        { typeof(PaperSheet), 0.01 },
        { typeof(ParchmentSheets), 0.1 }, // Több lap
        { typeof(Quill), 0.01 },
        { typeof(Quiver), 0.5 },
        { typeof(Rope20Meters), 4.0 }, // Kötél 20 méterenként
        { typeof(Sack), 0.1 },
        { typeof(Satchel), 0.3 },
        { typeof(Scales), 1.0 }, // Mérleg
        { typeof(SealingWax), 0.1 },
        { typeof(SewingNeedle), 0.001 },
        { typeof(Shovel), 2.0 },
        { typeof(SilkEll), 0.05 },
        { typeof(SwordSheathCommon), 0.5 },
        { typeof(SwordSheathOrnate), 0.8 },
        { typeof(TentSmall), 5.0 },
        { typeof(TentLarge), 10.0 },
        { typeof(TentMilitary), 15.0 },
        { typeof(Torch), 0.5 },
        { typeof(Waterskin), 0.5 }, // Üresen
        { typeof(Whetstone), 0.3 },
        { typeof(Whistle), 0.01 },

        // ==============================================================================
        // --- Shields (kg) ---
        // ==============================================================================
        { typeof(SmallShield), 3.0 },
        { typeof(MediumShield), 5.0 },
        { typeof(LargeShield), 8.0 },
        // A Shield.cs valószínűleg egy abstract vagy alaposztály, de ha van súlya:
        // { typeof(Shield), 4.0 }, 

        // ==============================================================================
        // --- Trappings (kg) ---
        // ==============================================================================
        { typeof(Halter), 0.5 }, // Kantár
        { typeof(HorseBlanket), 2.0 },
        { typeof(HorseshoeAndShoeing), 1.0 }, // Egy garnitúra patkó
        { typeof(Saddlebags), 1.0 }, // Táskák, üresen
        { typeof(ChariotTools), 5.0 }, // Kocsieszközök
        { typeof(ReinsBridleSnaffle), 1.0 }, // Zabla és gyeplő
        { typeof(YokeHorseHarness), 5.0 }, // Hám
        
        // Nyergek
        { typeof(PackSaddle), 5.0 }, // Málhanyereg
        { typeof(TravellingSaddle), 10.0 }, // Utazó nyereg
        { typeof(CombatSaddle), 15.0 }, // Harci nyereg (vagy 10 kg, ha a WarSaddle.cs is létezik)
        { typeof(WarSaddle), 15.0 }, // Harci nyereg a MagicalObjects mappából is átrakva (WarSaddle.cs a Trappings-ben is kéne hogy legyen, de a MagicalObjects-ben is szerepel, így az érték itt is hasznos)
        
    };

    public static double GetWeight(Thing thing)
    {
        ArgumentNullException.ThrowIfNull(thing);

        var thingType = thing.GetType();
        if (Weights.TryGetValue(thingType, out var weight))
        {
            return weight;
        }

        var weightProperty = thingType.GetProperty("Weight", BindingFlags.Public | BindingFlags.Instance);
        if (weightProperty != null && weightProperty.PropertyType == typeof(double))
        {
            try
            {
                return (double)weightProperty.GetValue(thing);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error retrieving Weight property via reflection for {thingType.Name}: {ex.Message}");
            }
        }

        return 0.0;
    }
}