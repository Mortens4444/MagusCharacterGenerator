using System.ComponentModel;

namespace M.A.G.U.S.GameSystem.Attributes;

public enum ThrowType
{
	[Description("1D6")]
	_1K6,
	[Description("2D6")]
	_2K6,
    [Description("1D10")]
    _1K10,
    [Description("2D10")]
    _2K10,
    [Description("3D10")]
    _3K10,
    [Description("3D6")]
	_3K6,
	[Description("3D6")]
	_3K6_2_Times,
	[Description("1D1")]
	_1K1,
	[Description("1D5")]
	_1K5,
	[Description("1D2")]
	_1K2,
	[Description("1D100")]
	_1K100,
	[Description("1D10")]
	_1K10_2_Times,
	[Description("1D3")]
	_1K3,
	[Description("3D100")]
	_3K100,
}
