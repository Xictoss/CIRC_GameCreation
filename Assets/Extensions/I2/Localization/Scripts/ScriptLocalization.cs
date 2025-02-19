using UnityEngine;

namespace I2.Loc
{
	public static class ScriptLocalization
	{

		public static string MENU_ACTU 		{ get{ return LocalizationManager.GetTranslation ("MENU ACTU"); } }
		public static string MENU_CODEX 		{ get{ return LocalizationManager.GetTranslation ("MENU CODEX"); } }
		public static string MENU_EXPLORATION 		{ get{ return LocalizationManager.GetTranslation ("MENU EXPLORATION"); } }
		public static string MENU_GRANDE_CUISINE 		{ get{ return LocalizationManager.GetTranslation ("MENU GRANDE CUISINE"); } }
		public static string MENU_HISTOIRE 		{ get{ return LocalizationManager.GetTranslation ("MENU HISTOIRE"); } }
		public static string MENU_QUITTER 		{ get{ return LocalizationManager.GetTranslation ("MENU QUITTER"); } }
		public static string MENU_TEXTE_ACTU 		{ get{ return LocalizationManager.GetTranslation ("MENU TEXTE ACTU"); } }
		public static string MENU_TUTORIAL 		{ get{ return LocalizationManager.GetTranslation ("MENU TUTORIAL"); } }
		public static string OPTIONS_LANGUE 		{ get{ return LocalizationManager.GetTranslation ("OPTIONS LANGUE"); } }
		public static string GAMEITEM_USTENSIL 		{ get{ return LocalizationManager.GetTranslation ("GAMEITEM USTENSIL"); } }
		public static string GAMEITEM_INGREDIENT 		{ get{ return LocalizationManager.GetTranslation ("GAMEITEM INGREDIENT"); } }
	}

    public static class ScriptTerms
	{

		public const string MENU_ACTU = "MENU ACTU";
		public const string MENU_CODEX = "MENU CODEX";
		public const string MENU_EXPLORATION = "MENU EXPLORATION";
		public const string MENU_GRANDE_CUISINE = "MENU GRANDE CUISINE";
		public const string MENU_HISTOIRE = "MENU HISTOIRE";
		public const string MENU_QUITTER = "MENU QUITTER";
		public const string MENU_TEXTE_ACTU = "MENU TEXTE ACTU";
		public const string MENU_TUTORIAL = "MENU TUTORIAL";
		public const string OPTIONS_LANGUE = "OPTIONS LANGUE";
		public const string GAMEITEM_USTENSIL = "GAMEITEM USTENSIL";
		public const string GAMEITEM_INGREDIENT = "GAMEITEM INGREDIENT";
	}
}