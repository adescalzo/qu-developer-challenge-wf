namespace QuWordFinder.Application.Tests.TestingSupport;

public static class MatrixExamples
{
    /*
    Example 1

    Not in list:
        MICROPHONE: Not
        WALLET: Not
    
    Horizontally:
    
        DOLPHIN: Row 0, columns 0–6
        TECHNOLOGY: Row 1, columns 5–14
        TABLE: Row 4, columns 10–14
        HORSE: Row 7, columns 0–4
        RABBIT: Row 8, columns 5–10
        MOUSE: Row 10, columns 2–6
        CHURCH: Row 14, columns 10–15
    
    Vertically:
        DOCTOR: Column 19, rows 1–6
        PORK: Column 1, rows 14–17
        PICKUP: Column 20, rows 12–17
   */

    public static readonly string[] Words1 = [
        "DOLPHIN",
        "TABLE",
        "DOCTOR",
        "TECHNOLOGY",
        "WALLET",
        "MOUSE",
        "CHURCH",
        "MICROPHONE",
        "HORSE",
        "RABBIT",
        "PORK",
        "PICKUP"
    ];

    public static readonly string[] WordsOk1 = [
        "DOLPHIN",
        "TABLE",
        "DOCTOR",
        "TECHNOLOGY",
        "MOUSE",
        "CHURCH",
        "HORSE",
        "RABBIT",
        "PORK",
        "PICKUP"
    ];

    public static readonly string[] Matrix1 = [
        "DOLPHINWUWBVQGKOIEHW", // Row 0
        "AKVDPTECHNOLOGYFOBND", // Row 1
        "WXMPCTERXOFDRAZYPVSO", // Row 2
        "BMRIIFCTGSWVXKPLQHEC", // Row 3
        "GLWZRVLJCWTABLEHCBOT", // Row 4
        "FLKBUDXJOYAISGNXMVTO", // Row 5
        "QZEVOGDNAPSHRWFTULIR", // Row 6
        "HORSECRLWFEVQUKDNJRY", // Row 7
        "HNFKMRABBITNXRBGYTOC", // Row 8
        "VDUZFJRZMTWCPHLYKSAX", // Row 9
        "YBMOUSEONVLUCIGQWMDP", // Row 10
        "KOREPVXZDWYSANFUTGJH", // Row 11
        "WDUCEKALPNOBTQIMVZYP", // Row 12
        "OXSAWQJFHRDKGLNEVXCI", // Row 13
        "PIDYRMAGCHCHURCHXQNC", // Row 14
        "OJKEVBSYPXQFHWOMIRLK", // Row 15
        "RPGUZCMBTRXYLAIHFDWU", // Row 16
        "KMBTOERWLYPVCDIUSKHP", // Row 17
        "REILNPSHCFAZVXGQJUTK", // Row 18
        "QLWANMZKDGFRIEOPSXHC"  // Row 19
    ];

    /*
    Example 2
    
    Not in list:
        MICROPHONE
        WALLET

    Horizontally:
       
       COMPUTER: Row 16, columns 0–7
       DOLPHIN: Row 17, columns 16–23
       TABLE: Row 18, columns 24–28
       HORSE: Row 19, columns 18–22
       MONKEY: Row 20, columns 0–5
       RABBIT: Row 20, columns 18–23
       CHURCH: Row 21, columns 8–13
       MOUSE: Row 23, columns 0–4
       TREE: Row 14, columns 0–3
       
    Vertically (6 words):
    
       MICROPHONE: Column 38, rows 0–9
       SILVER: Column 39, rows 16–29
       BREEZE: Column 18, rows 3–7
       VECTOR: Column 16, rows 1–7
       RANDOM: Column 10, rows 4–9
       STELLAR: Column 5, rows 4–10
       MOUSE: Column 6, rows 7–11
    */

    public static readonly string[] Words2 =
    [
        "MICROPHONE",
        "COMPUTER",
        "DOLPHIN",
        "TABLE",
        "HORSE",
        "MONKEY",
        "DOCTOR",
        "TECHNOLOGY",
        "WALLET",
        "MOUSE",
        "CHURCH",
        "RABBIT",
        "PORK",
        "PICKUP",
        "TREE",
        "SILVER",
        "BREEZE",
        "VECTOR",
        "RANDOM",
        "STELLAR"
    ];

    public static readonly string[] Matrix2 =
    [
        "ABCDEFGHIJKLMABCDEFGHIJKLMNOABCDEFGHIJML", // Row 0
        "ABCDEFGHIJKLMABCVEFGHIJKLMNOABCDEFGHIJIL", // Row 1
        "ABCDEFGHIJKLMABCEEFGHIJKLMNOABCDEFGHIJCL", // Row 2
        "ABCDEFGHIJKLMABCCEBGHIJKLMNOABCDEFGHIJRL", // Row 3
        "ABCDESGHIJRLMABCTEEGHIJKLMNOABCDEFGHIJOL", // Row 4
        "ABCDETGHIJALMABCOEEGHIJKLMNOABCDEFGHIJPL", // Row 5
        "ABCDEEGHIJNLMABCREZGHIJKLMNOABCDEFGHIJHL", // Row 6
        "ABCDELMHIJDLMABCDEEGHIJKLMNOABCDEFGHIJOL", // Row 7
        "ABCDELOHIJOLMABCDEXGHIJKLMNOABCDEFGHIJNL", // Row 8
        "ABCDEAUHIJMLMABCDEFGHIJKLMNOABCDEFGHIJEL", // Row 9
        "ABCDERSHIJKLMABCDEFGHIJKLMNOABCDEFGHIJKL", // Row 10
        "ABCDEFEHIJKLMABCDEFGHIJKLMNOABCDEFGHIJKL", // Row 11
        "ABCDEFGHIJKLMABCDEFGHIJKLMNOABCDEFGHIJKL", // Row 12
        "ABCDEFGHIJKLMABCDEFGHIJKLMNOABCDEFGHIJKL", // Row 13
        "ABCDEFGHIJKLMABCDEFGHIJKLMNOABCDEFGHIJKL", // Row 14
        "ABCDEFGHIJKLMABCDEFGHIJKLMNOABCDEFGHIJKL", // Row 15
        "COMPUTERABCDEFGHIJKLMNOQRSTUVWXYZABCDEFS", // Row 16
        "XYZABCDEFGHIJKLMONDOLPHINOPQRSTUVWXYZABI", // Row 17
        "OPQRSTUVWXYZABCDEFGHIJKLMTABLEDEFGHIJKLL", // Row 18
        "ABCDEFGHIJKLMNOPQHORSESTUVWXYZABCDEFGHIV", // Row 19
        "MONKEYABCDEFGHIJKLMNRABBITUVWXYZABCDEFGE", // Row 20
        "ABCDEFGHIJKLMABCDEFGHIJKLMNOABCDEFGHIJKR", // Row 21
        "ABCDEFGHCHURCHABCDEFGHIJKLMNOQRSTUVWXYZA", // Row 22
        "ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMN", // Row 23
        "MOUSEABCDEFGHIJKLMNOPQRSTUVABCDEFGHIJKLM", // Row 24
        "ABCDEFGHIJKLMNOPQRSTACORNBCDEFGHIJKLMNOP", // Row 25
        "ABCDEFGHIJKLMNABCDEFGHIJKLRACCOONSTUVWXY", // Row 26
        "ABCDEFGHIJKLMABCDEFGHIJKLMMACHINEFGHIJKL", // Row 27
        "ABCDEFGHIJKLMNOPQABCDEFGHIJKLMNOPQRSTUVW", // Row 28
        "ABCDEFGHIJKLMABCDEFGHIJKLMABCDEFGHIJKLMN", // Row 29
        "TREEABCDEFGHIJKLMNOPQRSTUVWXABCDEFGHIJKL", // Row 30
        "ABCDEFGHIJKLMABCDEFGHIJKLMNOABCDEFGHIJKL", // Row 31
        "ABCDEFGHIJKLMABCDEFGHIJKLMNOABCDEFGHIJKL", // Row 32
        "ABCDEFGHIJKLMABCDEFGHIJKLMNOABCDEFGHIJKL", // Row 33
        "ABCDEFGHIJKLMABCDEFGHIJKLMNOABCDEFGHIJKL", // Row 34
        "ABCDEFGHIJKLMABCDEFGHIJKLMNOABCDEFGHIJKL", // Row 35
        "ABCDEFGHIJKLMABCDEFGHIJKLMNOABCDEFGHIJKL", // Row 36
        "ABCDEFGHIJKLMABCDEFGHIJKLMNOABCDEFGHIJKL", // Row 37
        "ABCDEFGHIJKLMABCDEFGHIJKLMNOABCDEFGHIJKL", // Row 38
        "ABCDEFGHIJKLMABCDEFGHIJKLMNOABCDEFGHIJKL"  // Row 39
    ];
}