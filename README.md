# All_Name_Validate
萬用的驗證命名正確性_DesignPatten_策略模式

要驗證Name的正確性, 但不同的狀況對正確的定義不同,希望能應對各種規則

策略模式: 希望class Member都不用改(關閉), 所以用Interface對付各種狀況(開放),

Case1 必填, 

RequiredValidator : IValidator, RequiredValidator 實作Validator介面

用string.IsNullOrEmpty(value)來判斷

若是Null或Empty報錯

class Member裡, 屬性Validators的宣告型別是List<IValidator>, 此集合是所有驗證規則, 用 foreach來run各種規則

在主程式, 宣告變數validators,用來存放要用的驗證規則

new 一個 Member,並帶入驗證規則 validators, 這裡便可做到報錯, 但程式就不會繼續跑了...

用try catch包住, "Name錯誤, 原因: " + ex.Message

Case2 : 驗證長度, 

MaxlengthValidator 實作Validator介面

readonly的field可以用建構子改值一次

建構子MaxlengthValidator(int maxLength)可以帶入最大值參數, 判斷長度, 超過就丟出例外

要注意!  string.Length在字串是null時會報錯, 故if (string.IsNullOrEmpty(value)) return true;

在Main, validators裡new MaxlengthValidator(12), 字串長度超過12會報錯

> 後續有新的驗證規則, 便可透過實作IValidator介面來新增, class Member完全不用改
