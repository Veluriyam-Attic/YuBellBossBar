namespace YuBellBossBar.ModCross;

internal class CalamityBarHealth
{
    public static bool CalamityLoaded = false;

    public static Type bossHPUI = null;

    public static Type bossHealthBarManager = null;

    public static ConstructorInfo constructor = null;

    public static MethodInfo updateMethod = null;

    public static FieldInfo oneToMany = null;

    public static Dictionary<int, int[]> OneToMany = null;

    internal static (long?, long?, long?) DoSomeReflection(int npcIndex,int npcType)
    {
        if (!YuBellBossBar.CalamityAdapt)
            return (null, null, null);

        // 创建BossHPUI实例
        // Create an instance of BossHPUI
#pragma warning disable IDE0300
        object BossHPUI = constructor.Invoke(new object[] { npcIndex, null });

        // 手动设置必要字段  
        var intendedTypeField = bossHPUI.GetField("IntendedNPCType");
        intendedTypeField?.SetValue(BossHPUI, npcType);

        // 调用Update方法
        // Invoke the Update method
        updateMethod?.Invoke(BossHPUI, null);

        // 想不到怎么不使用反射来获取这个,那就反射吧,总比JITWhenEnabled好
        // I can't think of a way to get this without using reflection, so let's use reflection, it's better than JITWhenEnabled
        {
            // 获取CombinedNPCLife属性
            // Get the CombinedNPCLife property
            PropertyInfo combinedLifeProperty = bossHPUI.GetProperty("CombinedNPCLife");
            long combinedLife = (long)combinedLifeProperty.GetValue(BossHPUI);

            // 获取CombinedNPCMaxLife属性
            // Get the CombinedNPCMaxLife property
            PropertyInfo combinedMaxLifeProperty = bossHPUI.GetProperty("CombinedNPCMaxLife");
            long combinedMaxLife = (long)combinedMaxLifeProperty.GetValue(BossHPUI);

            // 获取InitialMaxLife字段
            // Get the InitialMaxLife field
            FieldInfo initialMaxLifeField = bossHPUI.GetField("InitialMaxLife");
            long initialMaxLife = (long)initialMaxLifeField.GetValue(BossHPUI);

#if DEBUG
            Main.NewText("[c/FF0000:Received Params From Calamity Mod: " + combinedLife + "/" + combinedMaxLife + "---" + initialMaxLife + "]");
#endif
            return ((long?)combinedLife, (long?)combinedMaxLife,(long?)initialMaxLife);
        }
    }
}
