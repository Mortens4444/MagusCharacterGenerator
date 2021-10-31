using Mtf.Languages.LanguageElemtLoader;
using Mtf.Languages.LanguageElemtLoader.Csv;
using Mtf.Languages.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.ComboBox;
using static System.Windows.Forms.Control;
using static System.Windows.Forms.Menu;

namespace Mtf.Languages
{
	public static class Lng
	{
		public static readonly Dictionary<(Language Language, string ElementIdentifier), List<string>> AllLanguageElements;

		//private static ILanguageElementLoader languageElementLoader = new JsonLanguageElementLoader();
		private static readonly ILanguageElementLoader languageElementLoader = new CsvLanguageElementLoader();

		static Lng()
        {
			AllLanguageElements = languageElementLoader.LoadElements();
		}

		/// <summary>
		/// Translates a Windows.Forms.Form.
		/// </summary>
		/// <param name="form">The Form to be translated.</param>
		public static void Translate(Form form)
		{
			form.Text = Elem(form.Text);
			Translate(form.Controls);
		}

		/// <summary>
		/// Translates a ControlCollection.
		/// </summary>
		/// <param name="controls">The ControlCollection to be translated.</param>
		public static void Translate(ControlCollection controls)
		{
			foreach (var control in controls)
			{
				if (control is WebBrowser)
				{
					continue;
				}

				if (control is Control controlWithTextProperty)
				{
					controlWithTextProperty.Text = Elem(controlWithTextProperty.Text);
					Translate(controlWithTextProperty.Controls);
					if (controlWithTextProperty.ContextMenuStrip != null)
					{
						Translate(controlWithTextProperty.ContextMenuStrip.Items);
					}
				}

				if (control is ListView listview)
				{
					foreach (ListViewGroup listViewGroup in listview.Groups)
					{
						listViewGroup.Header = Elem(listViewGroup.Header);
					}
					foreach (ColumnHeader column in listview.Columns)
					{
						column.Text = Elem(column.Text);
					}					
				}
				else if (control is MenuStrip menuStrip)
				{
					Translate(menuStrip.Items);
				}
				else if (control is ComboBox comboBox)
				{
					Translate(comboBox, comboBox.Items);
				}
				else if (control is ContextMenuStrip contextMenuStrip)
				{
					Translate(contextMenuStrip.Items);
				}
				else if (control is ContextMenu contextMenu)
				{
					Translate(contextMenu.MenuItems);
				}
			}
		}

		private static void Translate(MenuItemCollection items)
		{
			if (items != null)
			{
				foreach (MenuItem item in items)
				{
					item.Text = Elem(item.Text);
					Translate(item.MenuItems);
				}
			}
		}

		private static void Translate(ComboBox comboBox, ObjectCollection items)
		{
			var result = new List<object>();
			for (int i = 0; i < items.Count; i++)
			{
				result.Add(items[i] is string text ? Elem(text) : items[i]);
			}
			comboBox.Items.Clear();
			comboBox.Items.AddRange(result.ToArray());
		}

		public static void Translate(ToolStripItemCollection toolStripItems)
		{
			foreach (ToolStripItem toolStripItem in toolStripItems)
			{
				toolStripItem.Text = Elem(toolStripItem.Text);
				if (toolStripItem is ToolStripMenuItem toolStripMenuItem)
				{
					Translate(toolStripMenuItem.DropDownItems);
				}
			}
		}

		[Obsolete("Maybe you want to use Translate(Form form) instead of this method.")]
		/// <summary>
		/// Load language elements for items, which has Text property.
		/// </summary>
		/// <param name="languageElementFillers">List of tuples. The first element of the tuple must have a Text property, and the second is the language element identifier which should be loaded.</param>
        public static void LoadLanguageElements(params (dynamic TextContainer, string LanguageElementIdentifier)[] languageElementFillers)
        {
            foreach (var (TextContainer, LanguageElementIdentifier) in languageElementFillers)
            {
                TextContainer.Text = Elem(LanguageElementIdentifier);
            }
        }

		public static string Elem(Language toLanguage, string element)
		{
			return Elem(TranslationCore.Language, toLanguage, element);
		}

		public static string Elem(Language fromLanguage, Language toLanguage, string element)
		{
			var fromElements = AllLanguageElements
				.Where(e => e.Key.Language == fromLanguage)
				.Select(e => (ElementIdentifier: e.Key.ElementIdentifier, Value: e.Value[0]))
				.ToDictionary(t => t.Value, t => t.ElementIdentifier);

			if (!fromElements.ContainsKey(element))
			{
				return element;
				//new Exception($"Translation not found for element '{element}' from language {fromLanguage}");
			}
			var elementIdentifier = fromElements[element];
			return GetLanguageElement(elementIdentifier, 0, toLanguage) ?? element;
		}

		/// <summary>
		/// Get a translation of an English expression.
		/// </summary>
		/// <param name="elementIdentifier">The requested element, which wanted to be translated.</param>
		/// <param name="index">Index of the specified translations. If not set, it will return the first translation.</param>
		/// <returns>Returns the translation or the requested element itself, if it is not present in the dictionary.</returns>
		public static string Elem(string elementIdentifier, int index = 0)
        {
            var result = GetLanguageElement(elementIdentifier, index, TranslationCore.Language);
            if (String.IsNullOrEmpty(result))
            {
                result = GetLanguageElement(elementIdentifier, index);
            }
            return String.IsNullOrEmpty(result) ? elementIdentifier : result;
        }

        private static string GetLanguageElement(string elementIdentifier, int index, Language language = Language.English)
        {
            var key = (language, elementIdentifier);
            return AllLanguageElements.ContainsKey(key) ? AllLanguageElements[key][index] : null;
        }
    }
}
