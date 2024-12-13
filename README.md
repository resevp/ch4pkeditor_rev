此軟件由 Enzo 創建，Rev 修改。基於 Enzo 3.0.3 的版本而修改成 Rev 1.0 版本。<br />
所以發佈版本稱爲：Enzo 3.0.3 + Rev 1.0<br />
Rev 版下載：https://github.com/resevp/ch4pkeditor_rev/releases<br />
Rev 版 Bug 報告：https://github.com/resevp/ch4pkeditor_rev/issues<br />
Rev 版討論區：https://github.com/resevp/ch4pkeditor_rev/discussions<br />

此專案已開源，有興趣的可以Fork回去改。<br />
若發現bug且有能力修復，也歡迎提PR。<br />
Enzo 版使用編程語言 C# .NET 4.5，WinForm。<br />
Rev 版使用編程語言 C# .NET 4.8，WinForm。<br />

軟件訊息：

原著：Enzo<br>
版本：3.0.3<br>
發佈日期：2020/6/25<br>
Enzo官網：https://sites.google.com/site/ch4pkeditor/Home<br>
Enzo源碼：https://github.com/enzoliu/ch4pkeditor<br>

修改者：Rev<br>
版本：1.0<br>
發佈日期：2024/12/13<br>
Rev官網：https://sites.google.com/view/ch4pkeditor-rev<br>
Rev源碼：https://github.com/resevp/ch4pkeditor_rev<br>

Rev 1.0 版的修改細節：

- 取消自動重讀游戲資料，改爲手動取讀。
- 支援繁體和簡體（GB2312）游戲版本。原本只支持繁體字（big5）
- 增加批量修改武將。原版只能逐一修改。
- 增加批量修改城市，並設置文化上限。原版只能逐一城市修改。
- 增加批量修改妻子懷孕。原版只能逐一修改。
- 解決bug：原版在搜索游戲程序時，只搜索特定的英文字母大小的程序名 (Ckw95.exe) 。如果你的游戲程序啓動名字是全小字母 (ckw95.exe)，或全大字母 (CKW95.exe)，修改器可能無法成功搜索。Rev 1.0 在搜索游戲 exe 時將忽略大小字母。
- 取讀游戲資料后，顯示將軍總數。(游戲武將數上限為 500 人)
