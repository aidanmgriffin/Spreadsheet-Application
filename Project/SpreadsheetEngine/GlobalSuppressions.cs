// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private", Justification = "<Instructions direct to make field protected.>", Scope = "member", Target = "~F:SpreadsheetEngine.Cell.celltext")]
[assembly: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private", Justification = "<Instructions direct to make field protected.>", Scope = "member", Target = "~F:SpreadsheetEngine.Cell.cellvalue")]
[assembly: SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:Element should begin with upper-case letter", Justification = "<Some lowercase to differentiate from field of same name>", Scope = "member", Target = "~P:SpreadsheetEngine.Cell.cellText")]
[assembly: SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:Element should begin with upper-case letter", Justification = "<Some lowercase to differentiate from field of same name>", Scope = "member", Target = "~P:SpreadsheetEngine.Cell.valueText")]
