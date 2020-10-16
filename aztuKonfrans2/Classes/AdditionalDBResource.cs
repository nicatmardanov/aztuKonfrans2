using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using aztuKonfrans2.Resources;

namespace aztuKonfrans2.Classes
{
    public class AdditionalDBResource
    {
        public static string[] degree
        {
            get
            {
                return new string[] { Resource.degree_1, Resource.degree_2, Resource.degree_3 };
            }
        }


        public static string[] title
        {
            get
            {
                return new string[] { Resource.title_1, Resource.title_2, Resource.title_3, Resource.title_4, Resource.title_5, Resource.title_6, Resource.title_7, Resource.title_8 };
            }
        }

        public static string[] topic
        {
            get
            {
                return new string[] { Resource.topic_1, Resource.topic_2, Resource.topic_3, Resource.topic_4, Resource.topic_5, Resource.topic_6, Resource.topic_7 };
            }
        }

        public static string[] country_az
        {
            get
            {
                string s = "Akrotiri və Dekeliya,Aland adaları,Albaniya,Almaniya,Amerika Samoası,Andorra,Angilya,Anqola,Antiqua və Barbuda,Argentina,Aruba,Avstraliya,Avstriya,Azərbaycan,Baham adaları,Banqladeş,Barbados,Belçika,Beliz,Belarus,Benin,Bermud adaları,Birləşmiş Ərəb Əmirlikləri,Boliviya,Bolqarıstan,Bosniya və Herseqovina,Botsvana,Böyük Britaniya,Braziliya,Bruney,Burkina-Faso,Burundi,Butan,Bəhreyn,Cersi,Cəbəli-Tariq,Cənubi Afrika Respublikası,Cənubi Sudan,Cənubi Koreya,Cibuti,Çad,Çexiya,Monteneqro,Çili,Çin Xalq Respublikası,Danimarka,Dominika,Dominikan Respublikası,Efiopiya,Ekvador,Ekvatorial Qvineya,Eritreya,Estoniya,Əfqanıstan,Əlcəzair,Farer adaları,Fələstin,Fici,Kot-d'İvuar,Filippin,Finlandiya,Folklend adaları,Fransa,Fransa Polineziyası,Gernsi,Gürcüstan,Haiti,Hindistan,Honduras,Honkonq,Xorvatiya,İndoneziya,İordaniya,İraq,İran,İrlandiya,İslandiya,İspaniya,İsrail,İsveç,İsveçrə,İtaliya,Kabo-Verde,Kamboca,Kamerun,Kanada,Kayman adaları,Keniya,Kipr,Kiribati,Kokos adaları,Kolumbiya,Komor adaları,Konqo Respublikası,Konqo Demokratik Respublikası,Kosovo,Kosta-Rika,Kuba,Kuk adaları,Küveyt,Qabon,Qambiya,Qana,Qətər,Qayana,Qazaxıstan,Qərbi Sahara,Qırğızıstan,Qrenada,Qrenlandiya,Quam,Qvatemala,Qvineya,Qvineya-Bisau,Laos,Latviya,Lesoto,Liberiya,Litva,Livan,Liviya,Lixtenşteyn,Lüksemburq,Macarıstan,Madaqaskar,Makao,Şimali Makedoniya,Malavi,Malayziya,Maldiv adaları,Mali,Malta,Marşall adaları,Mavriki,Mavritaniya,Mayotta,Meksika,Men adası,Mərakeş,Mərkəzi Afrika Respublikası,Mikroneziya,Milad adası,Misir,Myanma,Moldova,Monako,Monqolustan,Montserrat,Mozambik,Müqəddəs Yelena,Askenson və Tristan-da-Kunya adaları,Namibiya,Nauru,Nepal,Niderland,Niderland Antil adaları,Niger,Nigeriya,Nikaraqua,Niue,Norfolk adası,Norveç,Oman,Özbəkistan,Pakistan,Palau,Panama,Papua-Yeni Qvineya,Paraqvay,Peru,Pitkern adaları,Polşa,Portuqaliya,Prednestroviya,Puerto-Riko,Ruanda,Rumıniya,Rusiya,Salvador,Samoa,San-Marino,San-Tome və Prinsipi,Seneqal,Sen-Bartelemi,Sent-Kits və Nevis,Sent-Lüsiya,Sen-Marten,Sen-Pyer və Mikelon,Sent-Vinsent və Qrenadin,Serbiya,Seyşel adaları,Səudiyyə Ərəbistanı,Sinqapur,Slovakiya,Sloveniya,Solomon adaları,Somali,Somalilend,Sudan,Surinam,Suriya,Esvatini,Syerra-Leone,Şərqi Timor,KXDR,Şimali Marian adaları,Şpisbergen və Yan-Mayen,Şri-Lanka,Tacikistan,Tanzaniya,Tailand,Taivan - Çin Respublikası,Törks və Kaykos adaları,Tokelau,Tonqa,Toqo,Trinidad və Tobaqo,Tunis,Tuvalu,Türkiyə,Türkmənistan,Ukrayna,Uollis və Futuna,Uqanda,Uruqvay,Vanuatu,Vatikan,Venesuela,ABŞ,Britaniya Virgin adaları,Vyetnam,Yamayka,Yaponiya,Yeni Kaledoniya,Yeni Zelandiya,Yəmən,Yunanıstan,Zambiya,Zimbabve";
                string[] countries = s.Split(',');
                return countries;
            }
        }

        public static string[] country_en
        {
            get
            {
                string s = "Akrotiri and Dekeliya,Aland Islands,Albania,Germany,American Samoa,Andorra,Anguilla,Angola,Antigua and Barbuda,Argentina,Aruba,Australia,Austria,Azerbaijan,Bahamas,Bangladesh,Barbados,Belgium,Belize,Belarus,Benin,Bermuda Islands,United Arab Emirates,Bolivia,Bulgaria,Bosnia and Herzegovina,Botswana,Great Britain,Brazil,Brunei,Burkina-Faso,Burundi,Bhutan,Bahrain,Jersey,Gibraltar,Republic of South Africa,South Sudan,South Korea,Djibouti,Chad,Czech Republic,Montenegro,Chile,China,Denmark,Dominica,Dominican Republic,Ethiopia,Ecuador,Equatorial Guinea,Eritrea,Estonia,Afghanistan,Algeria,Farer Islands,Palestinian,Fici,Ivory Coast,Philippines,Finland,Folklend Islands,France,French Polynesia,Gernsi,Georgia,Haiti,India,Honduras,Hong Kong,Croatia,Indonesia,Jordan,Iraq,Iran,Ireland,Iceland,Spain,Israel,Sweden,Switzerland,Italy,Cape Verde,Cambodia,Cameroon,Canada,Cayman Islands,Kenya,Cyprus,Kiribati,Cocos Islands,Colombia,Comoros,Republic of the Congo,Democratic Republic of the Congo,Kosovo,Costa Rica,Cuba,Cook Islands,Kuwait,Gabon,Gambia,Ghana,Qatar,Guyana,Kazakhstan,Western Sahara,Kyrgyzstan,Grenada,Greenland,Guam,Guatemala,Guinea,Guinea-Bissau,Laos,Latvia,Lesotho,Liberia,Lithuania,Lebanon,Libya,Liechtenstein,Luxembourg,Hungary,Madagascar,Macau,Northern Macedonia,Malawi,Malaysia,Maldives,Mali,Malta,Marshall Islands,Mauritius,Mauritania,Mayotta,Mexico,Man Islands,Morocco,Central African Republic,Micronesia,Christmas Islands,Egypt,Myanmar,Moldova,Monaco,Mongolia,Monserat,Mozambique,Saint Helena,Ascension and Tristan da Cunha,Namibia,Nauru,Nepal,Netherlands,Netherlands Antilles,Niger,Nigeria,Nicaragua,Niue,Norfolk Islands,Norway,Oman,Uzbekistan,Pakistan,Palau,Panama,Papua-New Guinea,Paraguay,Peru,Pitcairn Islands,Poland,Portugal,Prednestroviya,Puerto Rico,Rwanda,Romania,Russia,Salvador,Samoa,San-Marino,São Tomé and Príncipe,Senegal,Saintjacques-Barthelemy,Saint Kitts and Nevis,Saint-Lucia,Collectivity of Saint Martin,Saint Pierre and Miquelon,Saint Vincent and the Grenadines,Serbia,Seychelles,Saudi Arabia,Singapore,Slovakia,Slovenia,Solomon Islands,Somalia,Somalilend,Sudan,Suriname,Syria,Esvatini,Sierra Leone,East Timor,North Korea,Northern Marian Islands,Spitsbergen,Sri Lanka,Tajikistan,Tanzania,Thailand,Taivan - Republic of China,Turks and Caicos Islands,Tokelau,Tonga,Togo,Trinidad and Tobago,Tunisia,Tuvalu,Turkey,Turkmenistan,Ukraine,Wallis and Futuna,Uganda,Uruguay,Vanuatu,Vatican City,Venezuela,United States,British Virgin Islands,Vietnam,Jamaica,Japan,New Caledonia,New Zealand,Yemen,Greece,Zambia,Zimbabwe";
                string[] countries = s.Split(',');
                return countries;
            }
        }


        public static string[] country_tr
        {
            get
            {
                string s = "Akrotiri ve Dekeliya,Aland Adaları,Arnavutluk,Almanya,Amerikan Samoası,Andorra,Anguilla,Angola,Antigua ve Barbuda,Arjantin,Aruba,Avustralya,Avusturya,Azerbaycan,Bahamalar,Bangladeş,Barbados,Belçika,Belize,Belarus,Benin,Bermuda Adaları,Birleşik Arap Emirlikleri,Bolivya,Bulgaristan,Bosna Hersek,Botsvana,Büyük Britanya,Brezilya,Brunei,Burkina-Faso,Burundi,Butan,Bahreyn,Jersey,Cebelitarık,Güney Afrika Cumhuriyeti,Güney Sudan,Güney Kore,Cibuti,Çad,Çek Cumhuriyeti,Karadağ,Şili,Çin,Danimarka,Dominika,Dominik Cumhuriyeti,Etiyopya,Ekvador,Ekvator Ginesi,Eritre,Estonya,Afganistan,Cezayir,Farer Adaları,Filistin,Fici,Fildişi Sahili,Filipinler,Finlandiya,Folklend Adaları,Fransa,Fransız Polinezyası,Gernsi,Gürcistan,Haiti,Hindistan,Honduras,Hong Kong,Hırvatistan,Endonezya,Ürdün,Irak,İran,İrlanda,İzlanda,İspanya,İsrail,İsveç,İsviçre,İtalya,Cape Verde,Kamboçya,Kamerun,Kanada ,Cayman Adaları,Kenya,Güney Kıbrıs Rum Kesimi,Kiribati,Cocos Adaları,Kolombiya,Komor Adaları,Kongo Cumhuriyeti,Demokratik Kongo Cumhuriyeti,Kosova,Kosta Rika,Küba,Cook Adaları,Kuveyt,Gabon,Gambiya,Gana,Katar,Guyana,Kazakistan,Batı Sahra,Kırgızistan,Grenada,Grönland,Guam,Guatemala,Gine,Gine-Bissau,Laos,Letonya,Lesoto,Liberya,Litvanya,Lübnan,Libya,Lihtenştayn,Lüksemburg,Macaristan,Madagaskar,Makao,Kuzey Makedonya,Malavi,Malezya,Maldivler,Mali,Malta,Marshall Adaları,Mauritius,Moritanya,Mayotta,Meksika,Man Adaları,Fas,Orta Afrika Cumhuriyeti,Mikronezya,Noel Adaları,Mısır,Myanmar,Moldova,Monako,Moğolistan,Monserat,Mozambik,Saint Helena,Yükseliş ve Tristan da Cunha,Namibya,Nauru,Nepal,Hollanda,Hollanda Antilleri,Nijer,Nijerya,Nikaragua,Niue,Norfolk Adaları,Norveç,Umman ,Özbekistan,Pakistan,Palau,Panama,Papua Yeni Gine,Paraguay,Peru,Pitcairn Adaları,Polonya,Portekiz,Prednestroviya,Porto Riko,Ruanda,Romanya,Rusya,Salvador,Samoa,San-Marino,São Tomé ve Príncipe,Senegal,Saintjacques-Barthelemy,Saint Kitts ve Nevis,Saint Lucia,Saint Martin,Saint Pierre ve Miquelon Koleksiyonu,Saint Vincent ve Grenadinler,Serbia,Seyşeller,Suudi Arabistan,Singapur,Slovakya,Slovenya,Solomon Adaları,Somali,Somalilend,Sudan,Surinam,Suriye,Esvatini,Sierra Leone,Doğu Timor,Kuzey Kore,Kuzey Marian Adaları,Spitsbergen,Sri Lanka,Tacikistan,Tanzanya,Tayland,Taivan - Çin Cumhuriyeti,Turks ve Caicos Adaları,Tokelau,Tonga,Togo,Trinidad ve Tobago,Tunus,Tuvalu,Türkiye,Türkmenistan,Ukrayna,Wallis ve Futuna Adaları,Uganda,Uruguay,Vanuatu,Vatikan,Venezuela,Amerika Birleşik Devletleri,İngiliz Virgin Adaları,Vietnam,Jamaika,Japonya,Yeni Kaledonya,Yeni Zelanda,Yemen,Yunanistan,Zambiya,Zimbabve";
                string[] countries = s.Split(',');
                return countries;
            }
        }

        public static string[] country
        {
            get
            {

                if (System.Threading.Thread.CurrentThread.CurrentUICulture.Name == "az")
                {
                    return country_az;
                }
                else if (System.Threading.Thread.CurrentThread.CurrentUICulture.Name == "tr")
                {
                    return country_tr;
                }
                else
                {
                    return country_en;
                }
            }
        }
    }
}