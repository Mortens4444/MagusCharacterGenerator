using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Storyteller
{
	public static class TreeNodeCollectionExtensions
    {
		public static void GetFilesAndFoldersWithClear(this TreeNodeCollection siblings, string path, int iconIndex, params string[] extensionFilters)
		{
			siblings.Clear();
			siblings.GetFilesAndFolders(null, path, iconIndex, extensionFilters);
		}

		public static void GetFilesAndFolders(this TreeNodeCollection siblings, string path, int iconIndex, params string[] extensionFilters)
		{
			siblings.GetFilesAndFolders(null, path, iconIndex, extensionFilters);
		}

		public static void GetFilesAndFolders(this TreeNodeCollection siblings, string filter, string path, int iconIndex, params string[] extensionFilters)
        {
            var directories = Directory.GetDirectories(path);
            foreach (var directory in directories)
            {
                var nodeName = Path.GetFileName(directory);
                var newParent = CreateNode(nodeName, directory, 0);
                siblings.Add(newParent);
				newParent.Nodes.GetFilesAndFolders(filter, directory, iconIndex, extensionFilters);
            }

            var files = GetFiles(path, filter, extensionFilters);
            foreach (var file in files)
            {
                var nodeName = Path.GetFileNameWithoutExtension(file);
                siblings.Add(CreateNode(nodeName, file, iconIndex));
            }
        }

		public static TreeNode CreateNode(string nodeName, object tag, int iconIndex)
        {
            return new TreeNode(nodeName, iconIndex, iconIndex)
            {
                Tag = tag
            };
        }

        private static IEnumerable<string> GetFiles(string path, string filter, params string[] extensionFilters)
        {
            var result = new List<string>();
            foreach (var extensionFilter in extensionFilters)
            {
				var fullFilter = String.IsNullOrEmpty(filter) ? extensionFilter : String.Concat("*", filter, extensionFilter);
				result.AddRange(Directory.GetFiles(path, fullFilter));
            }
            return result;
        }
    }
}
