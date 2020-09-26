using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agreement
{
    public class Localization
    {
        /// <summary>
        /// 0 being English, 1 being Russian.
        /// </summary>
        public static int Language = 0;
        
        public static string[] BTN_RCV_SIDE = { "I am the receiving side.", "Я принимающая сторона." };
        public static string[] BTN_SEND_SIDE = { "I am the sending side.", "Я отправляющая сторона." };
        public static string[] BTN_JUST_ENCRYPT = { "Encrypt using an existent key.", "Шифрование имеющимся ключом." };
        public static string[] BTN_CONFIRM = { "Confirm and process.", "Подтвердить и продолжить." };
        public static string[] BTN_GO_ENCRYPT = { "Proceed to encrypting.", "Перейти к шифрованию." };
        public static string[] BTN_ENCRYPT_TEXT = { "Encrypt the text.", "Зашифровать текст." };
        public static string[] BTN_DECRYPT_TEXT = { "Decrypt the string.", "Дешифровать строку." };
        public static string[] BTN_CONFIRM_KEY = { "Confirm the key defined.", "Подтвердить и применить ключ." };
        public static string[] BTN_SOURCE = { "Source code.", "Исходный код." };


        public static string[] LBL_PUBLIC1_RECV = { "Enter the text marked as first public.", "Впишите текст отправленный с пометкой Публичный 1." };
        public static string[] LBL_PUBLIC2_RECV = { "Enter the text marked as second public.", "Впишите текст отправленный с пометкой Публичный 2." };
        public static string[] LBL_RECEIVE_THIS = { "Enter the text marked with 'mix' mark.", "Впишите текст, который вы получили с пометкой 'mix'." };
        public static string[] LBL_SEND_THIS = { "Send this text with 'mix' mark to an opponent", "Отправьте оппоненту данный текст с пометкой 'mix'." };
        public static string[] LBL_OUTPUT_KEY = { "Use this key to encrypt messages. DONT SEND IT ANYWHERE, IT SHOULD BE PRIVATE", "Используйте этот ключ для шифрования. НИКОМУ ЕГО НЕ ОТПРАВЛЯЙТЕ! КЛЮЧ ДОЛЖЕН БЫТЬ ПРИВАТНЫМ!" };
        public static string[] LBL_CHECKSUM = { "If this string matches with the one your opponent got, your key is correct. You can send this string anywhere.", "Если данная строка совпадает со строкой оппонента, ваш ключ верный. Эту строку можно отправлять и показывать." };
        public static string[] LBL_PUBLIC1_SEND = { "Send this string marking it as the first public.", "Отправьте эту строку, пометив её как Публичный 1." };
        public static string[] LBL_PUBLIC2_SEND = { "Send this string marking it as the second public.", "Отправьте эту строку, пометив её как Публичный 2." };
        public static string[] LBL_YOUR_KEY = { "Your key to use for encryption and decryption.", "Ваш ключ для шифрования и дешифрования." };
        public static string[] LBL_MESSAGE_GOT = { "The message you want to encrypt or decrypt.", "Сообщение которое вы хотите расшифровать или зашифровать." };
        public static string[] LBL_ENCRYPTION_OUTPUT = { "Encrypted or decrypted result.", "Зашифрованное или дешифрованное сообщение." };
        public static string[] LBL_KEYLENGTH_BAR = { "Keylength slider. Goes from 256 to 2048 bits. (Dont change unless you know what it is for)", "Длина ключа. От 256 до 2048 битов. (Не меняйте если не знаете, что делаете)" };

        public static string GetLocal(string[] Object)
        {
            return Object[Language];
        }
    }
}
