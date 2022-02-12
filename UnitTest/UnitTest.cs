using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using class_conect = BankStorePlus.ConnectorDB;

namespace UnitTest
{
    /// <summary>
    /// Логика автоматизированного тестирования приложения 
    /// </summary
    [TestClass]
    public class UnitTest
    {
        class_conect Query = new class_conect();
        /// <summary>
        /// Тест на наличие соединения с базой данных навигаторов
        /// </summary>
        [TestMethod]
        public void TestMethodChekConnect()
        {
            // проверка коннекта (ожидаем значение 0 при удачном коннекте к БД)
            Assert.AreEqual(0, Query.Check_DB());
        }

        /// <summary>
        /// Тест на наличие производителей PRO и СПЕКТР-ВИДЕО в базе данных
        /// </summary>
        [TestMethod]
        public void TestMethodChekBrand()
        {
            // проверка наличия записей с PRO и СПЕКТР-ВИДЕО (без ошибок -2 и -3)
            Assert.AreNotEqual(-2, Query.Get_Brand_Data("PRO"));
            Assert.AreNotEqual(-3, Query.Get_Brand_Data("PRO"));
            Assert.AreNotEqual(-2, Query.Get_Brand_Data("СПЕКТР-ВИДЕО"));
            Assert.AreNotEqual(-3, Query.Get_Brand_Data("СПЕКТР-ВИДЕО"));
        }

        /// <summary>
        /// Тест на наличие 4 наименований счетчиков монет PRO в базе данных
        /// </summary>
        [TestMethod]
        public void TestMethodChekZap()
        {
            // проверка наличия 4 записей PRO в таблице Счетчики монет (тест провален, т.к. их 2)
            Assert.AreEqual(4, Query.Get_Data("PRO"));
        }
    }
}
