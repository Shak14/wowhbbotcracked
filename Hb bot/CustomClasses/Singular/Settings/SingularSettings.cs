﻿#region Revision Info

// This file is part of Singular - A community driven Honorbuddy CC
// $Author: apoc $
// $Date: 2011-04-18 04:40:36 +0200 (må, 18 apr 2011) $
// $HeadURL: http://svn.apocdev.com/singular/tags/v1/Singular/Settings/SingularSettings.cs $
// $LastChangedBy: apoc $
// $LastChangedDate: 2011-04-18 04:40:36 +0200 (må, 18 apr 2011) $
// $LastChangedRevision: 288 $
// $Revision: 288 $

#endregion

using System.ComponentModel;

using Styx;
using Styx.Helpers;

using DefaultValue = Styx.Helpers.DefaultValueAttribute;

namespace Singular.Settings
{
    internal class SingularSettings : Styx.Helpers.Settings
    {
        private static SingularSettings _instance;

        public SingularSettings() : base(SettingsPath + ".xml")
        {
        }

        public static string SettingsPath { get { return string.Format("{0}\\Settings\\SingularSettings_{1}", Logging.ApplicationPath, StyxWoW.Me.Name); } }

        public static SingularSettings Instance { get { return _instance ?? (_instance = new SingularSettings()); } }

        #region Misc

        [Setting]
        [Styx.Helpers.DefaultValue(false)]
        [Category("Misc")]
        [DisplayName("Debug Logging")]
        [Description("Enables debug logging from Singular. This will cause quite a bit of spam. Use it for diagnostics only.")]
        public bool EnableDebugLogging { get; set; }

        [Setting]
        [DefaultValue(true)]
        [Category("Buffs")]
        [DisplayName("Use Flask of Enhancement")]
        [Description("Use the alchemy 'Flask of Enhancement' item for a free hourly buff")]
        public bool UseAlchemyFlaskOfEnhancement { get; set; }

        [Setting]
        [DefaultValue(false)]
        [Category("Movement")]
        [DisplayName("Disable Movement")]
        [Description("Disable all movement within the CC. This will NOT stop it from charging, blinking, etc. Only moving towards units, and facing will be disabled.")]
        public bool DisableAllMovement { get; set; }

        #endregion

        #region Resting

        [Setting]
        [DefaultValue(true)]
        [Category("Rest")]
        [DisplayName("Wait for R. Sickness")]
        [Description("If true, your character will 'sit still' while Resurrection Sickness is active.")]
        public bool WaitForResSickness { get; set; }

        [Setting]
        [DefaultValue(50)]
        [Category("Rest")]
        [DisplayName("Rest Health")]
        [Description("Your character will eat when your health drops below this value")]
        public int DefaultRestHealth { get; set; }

        [Setting]
        [DefaultValue(50)]
        [Category("Rest")]
        [DisplayName("Rest Mana")]
        [Description("Your character will drink when your mana drops below this value")]
        public int DefaultRestMana { get; set; }

        #endregion

        #region Targeting

        [Setting]
        [DefaultValue(95)]
        [Category("Healing")]
        [DisplayName("Ignore Targets Health")]
        [Description("Ignore healing targets when their health is above this value.")]
        public int IgnoreHealTargetsAboveHealth { get; set; }

        #endregion

        #region Trinkets

        [Setting]
        [DefaultValue(false)]
        [Category("Trinkets")]
        [DisplayName("Use First Trinket")]
        public bool UseFirstTrinket { get; set; }

        [Setting]
        [DefaultValue(false)]
        [Category("Trinkets")]
        [DisplayName("Use Second Trinket")]
        public bool UseSecondTrinket { get; set; }

        [Setting]
        [DefaultValue(TrinketUsage.Never)]
        [Category("Trinkets")]
        [DisplayName("First Trinket Usage")]
        public TrinketUsage FirstTrinketUsage { get; set; }

        [Setting]
        [DefaultValue(TrinketUsage.Never)]
        [Category("Trinkets")]
        [DisplayName("Second Trinket Usage")]
        public TrinketUsage SecondTrinketUsage { get; set; }

        [Setting]
        [DefaultValue(25)]
        [Category("Trinkets")]
        [DisplayName("First Trinket Use At Percent")]
        [Description(
            "The percent of health, or mana, to use this trinket at. Only taken into account when First Trinket Usage is 'LowHealth' or 'LowPower'")]
        public int FirstTrinketUseAtPercent { get; set; }

        [Setting]
        [DefaultValue(25)]
        [Category("Trinkets")]
        [DisplayName("Second Trinket Use At Percent")]
        [Description(
            "The percent of health, or mana, to use this trinket at. Only taken into account when Second Trinket Usage is 'LowHealth' or 'LowPower'")]
        public int SecondTrinketUseAtPercent { get; set; }

        [Setting]
        [DefaultValue(PvPTrinketSlot.None)]
        [Category("PVP")]
        [DisplayName("PVP Trinket slot")]
        public PvPTrinketSlot PvPTrinketSlot { get; set; }

        [Setting]
        [DefaultValue(PvPTrinketSlot.None)]
        [Category("PVP")]
        [DisplayName("PVP Damage Trinket slot")]
        [Description("Defines slot with trinket that greatly increase damage, will be used in sequence with such CD abilitites like Paladin's Avenging Wrath")]
        public PvPTrinketSlot PvPDamageTrinketSlot { get; set; }

        #endregion

        #region Class Late-Loading Wrappers

        // Do not change anything within this region.
        // It's written so we ONLY load the settings we're going to use.
        // There's no reason to load the settings for every class, if we're only executing code for a Druid.

        private DeathKnightSettings _dkSettings;

        private DruidSettings _druidSettings;

        private HunterSettings _hunterSettings;

        private MageSettings _mageSettings;

        private PaladinSettings _pallySettings;

        private PriestSettings _priestSettings;

        private RogueSettings _rogueSettings;

        private ShamanSettings _shamanSettings;

        private WarlockSettings _warlockSettings;

        private WarriorSettings _warriorSettings;

        [Browsable(false)]
        public DeathKnightSettings DeathKnight { get { return _dkSettings ?? (_dkSettings = new DeathKnightSettings()); } }

        [Browsable(false)]
        public DruidSettings Druid { get { return _druidSettings ?? (_druidSettings = new DruidSettings()); } }

        [Browsable(false)]
        public HunterSettings Hunter { get { return _hunterSettings ?? (_hunterSettings = new HunterSettings()); } }

        [Browsable(false)]
        public MageSettings Mage { get { return _mageSettings ?? (_mageSettings = new MageSettings()); } }

        [Browsable(false)]
        public PaladinSettings Paladin { get { return _pallySettings ?? (_pallySettings = new PaladinSettings()); } }

        [Browsable(false)]
        public PriestSettings Priest { get { return _priestSettings ?? (_priestSettings = new PriestSettings()); } }

        [Browsable(false)]
        public RogueSettings Rogue { get { return _rogueSettings ?? (_rogueSettings = new RogueSettings()); } }

        [Browsable(false)]
        public ShamanSettings Shaman { get { return _shamanSettings ?? (_shamanSettings = new ShamanSettings()); } }

        [Browsable(false)]
        public WarlockSettings Warlock { get { return _warlockSettings ?? (_warlockSettings = new WarlockSettings()); } }

        [Browsable(false)]
        public WarriorSettings Warrior { get { return _warriorSettings ?? (_warriorSettings = new WarriorSettings()); } }

        #endregion
    }
}