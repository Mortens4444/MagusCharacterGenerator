using System.ComponentModel;

namespace M.A.G.U.S.GameSystem.Attributes;

// New ThrowTypes should be implemented in DiceThrow.Throw method also and the description should be present in LanguageElements.ods.
public enum ThrowType
{
	[Description("1D6")]
	_1D6,
	[Description("2D6")]
	_2D6,
    [Description("1D10")]
    _1D10,
    [Description("2D10")]
    _2D10,
    [Description("3D10")]
    _3D10,
    [Description("3D6")]
	_3D6,
	[Description("3D6 (2x)")]
	_3D6_2_Times,
    [Description("1D1")]
    _1D1,
    [Description("1D9")]
    _1D9,
    [Description("1D5")]
	_1D5,
	[Description("1D2")]
	_1D2,
	[Description("1D100")]
	_1D100,
	[Description("1D10 (2x)")]
	_1D10_2_Times,
	[Description("1D3")]
	_1D3,
	[Description("3D100")]
	_3D100,
    [Description("4D10")]
    _4D10,
    [Description("10D10")]
    _10D10,
}
