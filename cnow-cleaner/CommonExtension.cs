using System.ComponentModel;

namespace cnow_cleaner;

internal static class CommonExtension
{
    #region string

    /// <summary>
    /// 使用字典进行替换
    /// <para>字典中Key为空的键值对将被跳过</para>
    /// </summary>
    public static string ReplaceBy(this string str, Dictionary<string, string> replaceDict)
    {
        var res = str;
        foreach (var item in replaceDict)
        {
            if (item.Key.IsValid())
                res = res.Replace(item.Key, item.Value);
        }
        return res;
    }

    /// <summary>
    /// 清除字符串中的不合法web转义字符
    /// </summary>
    public static string CleanInvalidWebStrings(this string str)
    {
        return str.Replace("&amp;", "&");
    }

    /// <summary>
    /// 移除字符串中相应的内容。
    /// <para>示例：
    /// <para>s = "abcd1234abcd"</para>
    /// <para>s.Remove("1234") // return "abcdabcd"</para></para>
    /// </summary>
    /// <param name="target">要移除的字符串</param>
    public static string Remove(this string str, string target)
    {
        return str.Replace(target, string.Empty);
    }

    /// <summary>
    /// 检测对象是否为非法字符串(为null或空字符串)
    /// </summary>
    /// <returns>为true代表对象是非法字符串</returns>
    public static bool IsInvalid(this string? str)
    {
        return string.IsNullOrEmpty(str);
    }
    /// <summary>
    /// 检测对象是否为合法字符串(不为null或空字符串)
    /// </summary>
    /// <returns>为true代表对象是合法字符串</returns>
    public static bool IsValid(this string? str)
    {
        return !string.IsNullOrEmpty(str);
    }
    #endregion

    #region KeyValuePair

    /// <summary>
    /// 以给定连接符将KeyValuePair的键值连接并返回
    /// </summary>
    public static string Join<T, K>(this KeyValuePair<T, K> kvp, string separator)
        where T : notnull
        where K : notnull
    {
        return kvp.Key + separator + kvp.Value;
    }
    #endregion

    #region List
    /// <summary>
    /// 使用给定的连接符将此列表中的元素依次展示出来
    /// <para>如果未指定连接符,则连接符会被默认为英文逗号</para>
    /// </summary>
    public static string Join<T>(this List<T> list, string separator = ",")
    {
        return string.Join(separator, list);
    }
    #endregion

    #region Dictionary
    /// <summary>
    /// 智能地向Value为List类型的Dictionary添加键值对
    /// <para>如果已经Dictionary内已经存在给定Key的键值对，那么向这个键值对的Value进行List.Add</para>
    /// <para>否则向Dictionary内插入一个新的键值对</para>
    /// </summary>
    public static void IntelligentAdd<T, K>(this Dictionary<T, List<K>> listDict, T key, K value)
        where T : notnull
    {
        if (listDict.TryGetValue(key, out List<K>? containedList))
            containedList.Add(value);
        else
            listDict.Add(key, [value]);
    }

    /// <summary>
    /// 获得一个按键(Key)排序后的字典
    /// </summary>
    /// <param name="desc">[可选,默认false] 是否为降序</param>
    public static Dictionary<T, K> SortByKey<T, K>(this Dictionary<T, K> dict, bool desc = false)
        where T : notnull
    {
        var ordered = desc ? dict.OrderByDescending(o => o.Key) : dict.OrderBy(o => o.Key);
        return ordered.ToDictionary(o => o.Key, p => p.Value);
    }

    /// <summary>
    /// 获得一个按值(Value)排序后的字典
    /// </summary>
    /// <param name="desc">[可选,默认false] 是否为降序</param>
    public static Dictionary<T, K> SortByValue<T, K>(this Dictionary<T, K> dict, bool desc = false)
        where T : notnull
        where K : notnull
    {
        var ordered = desc ? dict.OrderByDescending(o => o.Value) : dict.OrderBy(o => o.Value);
        return ordered.ToDictionary(o => o.Key, p => p.Value);
    }

    #endregion

    #region Image

    /// <summary>
    /// 获取图像 宽/高 中更大的那个值
    /// </summary>
    public static int MaxSideLength(this Image i)
    {
        return i.Width > i.Height ? i.Width : i.Height;
    }
    #endregion

    #region Enum
    /// <summary>
    /// 取得枚举描述
    /// </summary>
    public static string GetDescription(this Enum para)
    {
        var strValue = para.ToString();
        var fieldInfo = para.GetType().GetField(strValue);
        if (fieldInfo is null)
            return strValue;
        var objs = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
        if (objs.Length > 0)
            strValue = ((DescriptionAttribute)objs[0]).Description;
        return strValue;
    }
    #endregion

    #region DateTime

    /// <summary>
    /// 转换为Unix时间戳
    /// <para>时间戳单位：秒</para>
    /// </summary>
    public static long ToUnixTimeStamp(this DateTime dateTime)
    {
        return (long)dateTime.ToUniversalTime().Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
    }

    public static string ToFullDateText(this DateTime dateTime,
        string dateSeparator = ".", string dateTimeSeparator = " ", string timeSeparator = ":")
    {
        return $"{dateTime.ToString(
            $"yyyy{dateSeparator}MM{dateSeparator}dd" +
            $"{dateTimeSeparator}" +
            $"HH{timeSeparator}mm{timeSeparator}ss"
            )}";
    }

    #endregion

    #region long
    /// <summary>
    /// 按照Unix时间戳转换为DateTime
    /// <para>时间戳单位：秒</para>
    /// </summary>
    public static DateTime ToDateTime(this long timeStamp)
    {
        return DateTimeOffset.FromUnixTimeSeconds(timeStamp).DateTime.ToLocalTime();
    }
    #endregion
}
