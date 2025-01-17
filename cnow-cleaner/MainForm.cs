using System;

namespace cnow_cleaner;

public partial class MainForm : Form
{
    #region 程序初始化
    public MainForm()
    {
        InitializeComponent();
    }
    private void MainForm_Load(object sender, EventArgs e)
    {
        CbxGameRegion.SelectedIndex = 0;
        LabelVersionInfo.Text = "版本: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version?.ToString();
    }
    #endregion

    #region 顶部菜单
    private void 技术测试常见问题ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CommonTool.OpenUrl("https://bbs.nga.cn/read.php?tid=42971955");
    }
    private void 工具主页ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        CommonTool.OpenUrl("https://github.com/InfSein/cnow-cleaner");
    }
    #endregion


    #region 主要功能
    private void BtnCleanProcesses_Click(object sender, EventArgs e)
    {
        var result = CleanProcesses();
        CommonTool.ShowMsg(result);
    }
    private void BtnCleanRegedit_Click(object sender, EventArgs e)
    {
        var result = CleanRegedit();
        CommonTool.ShowMsg(result);
    }
    private void BtnCleanTempFiles_Click(object sender, EventArgs e)
    {
        var result = CleanTempFiles();
        CommonTool.ShowMsg(result);
    }

    private static string CleanProcesses()
    {
        List<string> targetProcesses = ["OWNeacClient.exe", "Overwatch.exe"];
        var result = CommonTool.TerminateProcesses(targetProcesses);
        return result;
    }
    private string CleanRegedit()
    {
        var path = @"Software\Blizzard Entertainment\Battle.net\Launch Options\Pro";
        var key = "Region";
        var val = CbxGameRegion.Text switch
        {
            "台服" => "TW",
            "美服" => "US",
            "韩服" => "KR",
            _ => ""
        };
        if (val == "")
            return "清理注册表失败:没有指定外服类型";
        var result = CommonTool.UpdateRegistryValue(path, key, val);
        if (result == "")
            result = "清理注册表成功";
        return result;
    }
    private string CleanTempFiles()
    {
        var filePath = @"C:\Windows\System32\drivers\OWNeacSafe.sys";
        var result = CommonTool.DeleteFileWithPermissions(filePath);
        return result;
    }
    #endregion

    #region 快捷操作
    private void BtnOneKeyRun_Click(object sender, EventArgs e)
    {
        var cleanProcessesResult = CleanProcesses();
        var cleanRegeditResult = CleanRegedit();
        var cleanTempFilesResult = CleanTempFiles();

        var msg = $@"[关闭OW与NEAC进程]
{cleanProcessesResult}

[清理注册表(外服商城修复)]
{cleanRegeditResult}

[清理国服临时文件]
{cleanTempFilesResult}";
        CommonTool.ShowMsg(msg);
    } 
    #endregion
}
