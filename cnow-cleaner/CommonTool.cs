using Microsoft.Win32;
using System.Data;
using System.Diagnostics;

namespace cnow_cleaner;

internal class CommonTool
{
    #region MessageBox Show
    public static void ShowMsg(string content, string title = "")
    {
        MessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    public static void ShowWarn(string content, string title = "")
    {
        MessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
    public static void ShowError(string content, string title = "")
    {
        MessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    public static bool ShowConfirm(string content, string title = "", MessageBoxIcon icon = MessageBoxIcon.Question)
    {
        return MessageBox.Show(content, title,
            MessageBoxButtons.YesNo,
            icon,
            MessageBoxDefaultButton.Button2
        ) == DialogResult.Yes;
    }
    #endregion

    #region Overwatch
    /// <summary>
    /// 关闭指定的进程
    /// </summary>
    public static string TerminateProcesses(List<string> processNames)
    {
        var result = new List<string>();
        foreach (var processName in processNames)
        {
            try {
                var processes = Process.GetProcessesByName(processName);
                var terError = "";
                foreach (var process in processes)
                {
                    try {
                        process.Kill();
                    } catch (Exception ex) {
                        terError += ex.Message + ";";
                    }
                }
                if (processes.Length == 0)
                    result.Add($"关闭'{processName}'成功(进程已经关闭)。");
                else if (terError.Length == 0)
                    result.Add($"关闭'{processName}'成功。");
                else
                    result.Add($"关闭'{processName}'失败: {terError}");
            } catch (Exception ex) {
                result.Add($"关闭'{processName}'失败: {ex.Message}");
            }
        }
        return string.Join(Environment.NewLine, result);
    }

    /// <summary>
    /// 修改注册表值
    /// </summary>
    public static string UpdateRegistryValue(string registryPath, string valueName, string newValue)
    {
        try
        {
            using RegistryKey? key = Registry.CurrentUser.OpenSubKey(registryPath, writable: true);
            if (key == null)
                return $"注册表路径不存在:'{registryPath}'";
            key.SetValue(valueName, newValue);
            return "";
        }
        catch (Exception ex)
        {
            return $"修改注册表失败: {ex.Message}";
        }
    }

    /// <summary>
    /// 删除指定文件
    /// </summary>
    public static string DeleteFile(string filePath)
    {
        try {
            if (!File.Exists(filePath))
                return $"删除'{filePath}'成功(文件已被删除)。";
            File.Delete(filePath);
            return $"删除'{filePath}'成功。";
        } catch (Exception ex) {
            var msg = ex.Message;
            if (msg.Contains("is denied"))
                msg = "访问被拒绝，请使用管理员权限打开本程序";
            return $"删除'{filePath}'失败: {msg}";
        }
    }
    public static string DeleteFileWithPermissions(string filePath)
    {
        try
        {
            if (!File.Exists(filePath))
                return $"删除'{filePath}'成功(文件已被删除)。";

            // 获取文件所有权
            string takeOwnCommand = $"takeown /f \"{filePath}\" /a";
            ExecuteCommandAsAdmin(takeOwnCommand);

            // 赋予文件完全控制权限
            string icaclsCommand = $"icacls \"{filePath}\" /grant administrators:F";
            ExecuteCommandAsAdmin(icaclsCommand);

            // 删除文件
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return $"删除'{filePath}'成功。";
            }
            else
            {
                return $"删除'{filePath}'期间出现意外:文件在获取授权期间丢失。";
            }
        }
        catch (Exception ex)
        {
            var msg = ex.Message;
            if (msg.Contains("is denied"))
                msg = "访问被拒绝，请使用管理员权限打开本程序";
            return $"删除'{filePath}'失败: {msg}";
        }

        static void ExecuteCommandAsAdmin(string command)
        {
            var processStartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/c {command}",
                Verb = "runas", // 使用管理员权限执行命令
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true
            };

            using var process = Process.Start(processStartInfo);
            process?.WaitForExit();
        }
    }
    #endregion

    #region Other

    /// <summary>
    /// 调用默认浏览器打开给定的URL
    /// </summary>
    public static void OpenUrl(string url)
    {
        dynamic? kstr;
        string s;
        try
        {
            // 从注册表中读取默认浏览器可执行文件路径
            RegistryKey? key2 = Registry.ClassesRoot.OpenSubKey(@"http\shell\open\command\");
            RegistryKey? key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http\UserChoice\");
            if (key != null)
            {
                kstr = key.GetValue("ProgId");
                if (kstr != null)
                {
                    s = kstr.ToString();
                    // "ChromeHTML","MSEdgeHTM" etc.
                    if (Registry.GetValue(@"HKEY_CLASSES_ROOT\" + s + @"\shell\open\command", null, null) is string path)
                    {
                        var split = path.Split('"');
                        path = split.Length >= 2 ? split[1] : "";
                        if (path != "")
                        {
                            Process.Start(path, url);
                            return;
                        }
                    }
                }
            }
            if (key2 != null)
            {
                kstr = key2.GetValue("");
                if (kstr != null)
                {
                    s = kstr.ToString();
                    var lastIndex = s.IndexOf(".exe", StringComparison.Ordinal);
                    if (lastIndex == -1)
                    {
                        lastIndex = s.IndexOf(".EXE", StringComparison.Ordinal);
                    }
                    var path = s.Substring(1, lastIndex + 3);
                    var result1 = Process.Start(path, url);
                    if (result1 == null)
                    {
                        var result2 = Process.Start("explorer.exe", url);
                        if (result2 == null)
                        {
                            Process.Start(url);
                        }
                    }
                }
            }
            else
            {
                var result2 = Process.Start("explorer.exe", url);
                if (result2 == null)
                {
                    Process.Start(url);
                }
            }
        }
        catch (Exception ex)
        {
            ShowError($"调用浏览器失败,因为{ex.Message}。\n链接已经被复制到您的剪贴板，请手动操作。");
            TryCopy(url);
        }
    }

    /// <summary>
    /// 尝试将给定文本复制到剪贴板
    /// </summary>
    /// <returns>是否成功复制</returns>
    public static bool TryCopy(string text)
    {
        try
        {
            Clipboard.SetText(text);
            return true;
        }
        catch
        {
            return false;
        }
    }

    #endregion
}
