using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Web.Routing;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Collections;

namespace AppetizerHtmlHelper
{
    public static class AppHtmlHelper
    {

        public static MvcHtmlString CustomAntiForgeryToken(this HtmlHelper htmlHelper)
        {
            StringBuilder tag = new StringBuilder();
            tag.Append("<input ");
            tag.Append("type = " + "\"" + "hidden" + "\"");
            tag.Append(" id = " + "\"" + "__RequestVerificationToken" + "\"");
            tag.Append(" Name=" + "\"" + "__RequestVerificationToken" + "\"");
            tag.Append(htmlHelper.AntiForgeryToken().ToString().Substring(htmlHelper.AntiForgeryToken().ToString().IndexOf(" value=\"")));
            return new MvcHtmlString(tag.ToString());
        }

        public static Kendo.Mvc.UI.Fluent.ButtonBuilder
        KendoButton(this HtmlHelper helper, string name, string caption, string htmlStyle = "")
        {
            if (string.IsNullOrEmpty(htmlStyle)) htmlStyle = "max-width: 100%;width: 100%;";
            return helper.Kendo().Button()
                .Name(name)
                .Content(caption)
                .HtmlAttributes(new { style = htmlStyle });
        }

        public static MvcHtmlString KendoCheckBox(this HtmlHelper helper, string name, bool isChecked = false)
        {
            return System.Web.Mvc.Html.InputExtensions.CheckBox(helper, name, isChecked, new { @class = "k-checkbox", style = "width: 100%;" });
        }
        public static MvcHtmlString KendoRadioButton(this HtmlHelper helper, string name, bool isChecked = false)
        {
            return System.Web.Mvc.Html.InputExtensions.RadioButton(helper, name, isChecked, new { @class = "k-radio", style = "width: 100%;" });
        }

        public static Kendo.Mvc.UI.Fluent.NumericTextBoxBuilder<double>
        KendoNumericBox(this HtmlHelper helper, string name, Int32 forval, string htmlStyle = "", string placeholder = "")
        {
            if (string.IsNullOrEmpty(htmlStyle)) htmlStyle = "width: 100%";
            return helper.Kendo().NumericTextBox()
                .Name(name)
                .Value(forval)
                .Spinners(false)
                .Decimals(0)
                .Format("0")
                .Min(0)
                .HtmlAttributes(new { style = htmlStyle, placeholder = placeholder });
        }

        public static Kendo.Mvc.UI.Fluent.NumericTextBoxBuilder<double>
        KendoNumericBox(this HtmlHelper helper, string name, Double forval, string htmlStyle = "", string placeholder = "")
        {
            if (string.IsNullOrEmpty(htmlStyle)) htmlStyle = "width: 100%";
            return helper.Kendo().NumericTextBox()
            .Name(name)
            .Value(forval)
            .Spinners(false)
            .Min(0)
            .HtmlAttributes(new { style = htmlStyle, placeholder = placeholder });
        }

        //public static MvcHtmlString NumericTextBox(this HtmlHelper helper, string name)
        //{

        //    //string str = "<input id = "Member1" type = "number" value = "@item.value.Member1" class="k - textbox text - right" style="width: 100 %; " />";
        //    return new MvcHtmlString(str);
        //}
        public static MvcHtmlString NumericTextBox(this HtmlHelper helper, string name, string forval, string maxlength, string htmlStyle = "", string placeholder = "")
        {
            return System.Web.Mvc.Html.InputExtensions.TextBox(helper, name, forval, new { @class = "k-textbox", style = htmlStyle, type = "number", placeholder = placeholder, maxlength = maxlength });
        }

        public static MvcHtmlString KendoTextArea(this HtmlHelper helper, string name, string forval, string maxlength, string cols, string rows, string htmlStyle = "", string placeholder = "")
        {
            if (string.IsNullOrEmpty(htmlStyle)) htmlStyle = "width: 100%";
            //return System.Web.Mvc.Html.TextAreaExtensions.TextArea(helper, name, forval, new { maxlenght=maxlength, @class = "k-textbox", style = "width: 100%;" });
            return System.Web.Mvc.Html.TextAreaExtensions.TextArea(helper, name, forval, new { @class = "k-textbox", style = htmlStyle, placeholder = placeholder, maxlength = maxlength, cols = cols, rows = rows });
        }
        public static Kendo.Mvc.UI.Fluent.TextBoxBuilder<string>
         KendoTextBox(this HtmlHelper helper, string name, string forval, string maxlength, string htmlStyle = "", string placeholder = "")
        {
            if (string.IsNullOrEmpty(htmlStyle)) htmlStyle = "width: 100%";
            return helper.Kendo().TextBox()
                .Name(name)
                .Value(forval)
                .HtmlAttributes(new { style = htmlStyle, placeholder = placeholder, maxlength = maxlength });
        }

        public static Kendo.Mvc.UI.Fluent.DateTimePickerBuilder
          KendoDateTime(this HtmlHelper helper, string name, DateTime forval, string htmlStyle = "")
        {
            if (string.IsNullOrEmpty(htmlStyle)) htmlStyle = "width: 100%";
            return helper.Kendo().DateTimePicker()
                .Name(name)
                .Value(forval)
                .HtmlAttributes(new { style = htmlStyle });
        }

        public static Kendo.Mvc.UI.Fluent.DatePickerBuilder
         KendoDate(this HtmlHelper helper, string name, DateTime forval, bool isDateEmpty = true, string htmlStyle = "")
        {
            if (string.IsNullOrEmpty(htmlStyle)) htmlStyle = "width: 100%";
            if (isDateEmpty)
                return helper.Kendo().DatePicker()
                    .Name(name)
                    //.Value(forval)
                    .Format("yyyy-MM-dd")
                    .HtmlAttributes(new { style = htmlStyle });
            else {
                return helper.Kendo().DatePicker()
                .Name(name)
                .Value(forval)
                .Format("yyyy-MM-dd")
                .HtmlAttributes(new { style = htmlStyle });
            }
        }
        public static Kendo.Mvc.UI.Fluent.DatePickerBuilder
        KendoDateTime(this HtmlHelper helper, string name, DateTime? forval, string htmlStyle = "")
        {
            if (string.IsNullOrEmpty(htmlStyle)) htmlStyle = "width: 100%";
            return helper.Kendo().DatePicker()
                .Name(name)
                .Value(forval)
                .HtmlAttributes(new { style = htmlStyle });
        }

        public static Kendo.Mvc.UI.Fluent.TimePickerBuilder
                 KendoTime(this HtmlHelper helper, string name, DateTime forval, string htmlStyle = "")
        {
            if (string.IsNullOrEmpty(htmlStyle)) htmlStyle = "width: 100%";
            return helper.Kendo().TimePicker()
                .Name(name)
                .Value(forval)
                .HtmlAttributes(new { style = htmlStyle });
        }

        public static Kendo.Mvc.UI.Fluent.ComboBoxBuilder
            KendoComboBox(this HtmlHelper helper, string name, string actionName, string coltrolerName,
            string forval, string htmlStyle = "", string Parm = "")
        {
            if (string.IsNullOrEmpty(htmlStyle)) htmlStyle = "width: 100%";
            return helper.Kendo().ComboBox()
                .Name(name)
                .Value(forval)
                .HtmlAttributes(new { style = htmlStyle })
                .DataTextField("Text")
                .DataValueField("Value")
                .Filter(FilterType.Contains)
                .DataSource(source =>
                {
                    source.Read(read =>
                    {
                        read.Action(actionName, coltrolerName, new { viewParms = Parm, controlName = name });
                    })
                    .ServerFiltering(false);
                })
                .SelectedIndex(0);
        }

        public static Kendo.Mvc.UI.Fluent.ComboBoxBuilder
           KendoComboBox(this HtmlHelper helper, string name, string[] listItems, string forval, string htmlStyle = "")
        {
            if (string.IsNullOrEmpty(htmlStyle)) htmlStyle = "width: 100%";
            return helper.Kendo().ComboBox()
                .Name(name)
                .Value(forval)
                .HtmlAttributes(new { style = htmlStyle })
                .Filter(FilterType.Contains)
                .BindTo(listItems)
                .Suggest(true)
                .Placeholder("Please Select Item");
        }

        public static Kendo.Mvc.UI.Fluent.DropDownListBuilder
           KendoDropDownList(this HtmlHelper helper, string name, string forval, string textField, string valueFiled, string htmlStyle = "",
            string optionLabel = "Please Select Item")
        {
            if (string.IsNullOrEmpty(htmlStyle)) htmlStyle = "width: 100%";
            return helper.Kendo().DropDownList()
                   .Name(name) //The name of the DropDownList is mandatory. It specifies the "id" attribute of the widget.
                   .Value(forval)
                   .HtmlAttributes(new { style = htmlStyle })
                   .DataTextField(textField) //Specify which property of the Product to be used by the DropDownList as a text.
                   .DataValueField(valueFiled) //Specify which property of the Product to be used by the DropDownList as a value.
                   .Filter(FilterType.Contains)
                   .OptionLabel(optionLabel); //Select the first item.

        }

        public static Kendo.Mvc.UI.Fluent.DropDownListBuilder
            KendoDropDownList(this HtmlHelper helper, string name, string forval, string controlerName,
            string actionName, string textField, string valueFiled, string htmlStyle = "", string optionLabel = "Please Select Item")
        {
            if (string.IsNullOrEmpty(htmlStyle)) htmlStyle = "width: 100%";
            return helper.Kendo().DropDownList()
                   .Name(name) //The name of the DropDownList is mandatory. It specifies the "id" attribute of the widget.
                   .Value(forval)
                   .HtmlAttributes(new { style = htmlStyle })
                   .DataTextField(textField) //Specify which property of the Product to be used by the DropDownList as a text.
                   .DataValueField(valueFiled) //Specify which property of the Product to be used by the DropDownList as a value.
                   .Filter(FilterType.Contains)
                   .DataSource(source =>
                   {
                       source.Read(read =>
                       {
                           read.Action(actionName, controlerName, new { _controlType = 0, _controlName = name }); //Set the Action and Controller names.
                       })
                   .ServerFiltering(false); //If true, the DataSource will not filter the data on the client.
                   })
                  .OptionLabel(optionLabel); //Select the first item.

        }

        public static Kendo.Mvc.UI.Fluent.ListViewBuilder<T>
            KendoListView<T>(this HtmlHelper helper, string name, string template, string controlerName, string actionName,
                             string htmlStyle = "", string Parm = "", int iPageSize = 10) where T : class
        {
            RouteValueDictionary rvd = new RouteValueDictionary();
            rvd.Add("_controlType", 1);
            rvd.Add("_controlName", name);
            rvd.Add("employeID", Parm); //need split key value array from given string and add to rvd

            if (string.IsNullOrEmpty(htmlStyle)) htmlStyle = "border:none;width: 100%";
            if (iPageSize > 0)
            {
                return helper.Kendo().ListView<T>()
                        .Name(name)
                        .TagName("div")
                        .ClientTemplateId(template)
                        .HtmlAttributes(new { style = htmlStyle })

                        .DataSource(dataSource =>
                        {
                            dataSource.Read(read => read.Action(actionName, controlerName));
                            dataSource.PageSize(iPageSize);
                            dataSource.ServerOperation(false);
                        }
                        )
                        .Pageable();
            }
            else
            {
                return helper.Kendo().ListView<T>()
                        .Name(name)
                        .TagName("div")
                        .ClientTemplateId(template)
                        .HtmlAttributes(new { style = htmlStyle })
                        .DataSource(dataSource =>
                        {
                            dataSource.Read(read => read.Action(actionName, controlerName));
                            dataSource.ServerOperation(true);
                        });
            }
        }

        public static Kendo.Mvc.UI.Fluent.GridBuilder<T>
           KendoGrid<T>(this HtmlHelper helper, string name, string controlerName, string actionName,
            string primaryKey = "", string filterParams = "", string updateAction = "", string destroyAction = "", int pageSize = 10, string htmlStyle = "") where T : class
        {
            if (string.IsNullOrEmpty(htmlStyle)) htmlStyle = "width: 100%";
            return helper.Kendo().Grid<T>()
                .Name(name)
                .HtmlAttributes(new { style = htmlStyle })
                //.Groupable()
                .Pageable()
                .Sortable()
                .Scrollable()
                .Filterable()
                .Pageable(pageable => pageable
                    .Refresh(true)
                    .PageSizes(true)
                    .ButtonCount(5)
                    )
                 .Selectable(selectable => selectable.Enabled(true).Mode(GridSelectionMode.Single).Type(GridSelectionType.Row))
                 .Events(e => e.DataBound("onRowBound"))
                 .DataSource(dataSource => dataSource
                    .Ajax()
                    .Read(read => read.Action(actionName, controlerName, new { id = filterParams }))
                    .PageSize(pageSize)
                    .ServerOperation(false)
                    .Model(model => model.Id(primaryKey))
                    .Update(update => update.Action(updateAction, controlerName))
                    .Destroy(update => update.Action(destroyAction, controlerName))

                );
        }

        public static Kendo.Mvc.UI.Fluent.MultiSelectBuilder
         KendoMultiSelect(this HtmlHelper helper, string name, IList<string> forval, string dataTextField, string dataValueField,
            string htmlStyle = "")
        {
            if (string.IsNullOrEmpty(htmlStyle)) htmlStyle = "width: 100%";
            return helper.Kendo().MultiSelect()
                .Name(name)
                //.Value(forval)
                .HtmlAttributes(new { style = htmlStyle })
                .DataTextField(dataTextField)
                .DataValueField(dataValueField)
                .Filter(FilterType.Contains);
        }

        public static Kendo.Mvc.UI.Fluent.MultiSelectBuilder
          KendoMultiSelect(this HtmlHelper helper, string name, string dataTextField, string dataValueField,
            string controlerName, string actionName, string htmlStyle = "")
        {
            if (string.IsNullOrEmpty(htmlStyle)) htmlStyle = "width: 100%";
            return helper.Kendo().MultiSelect()
                .Name(name)
                .HtmlAttributes(new { style = htmlStyle })
                .DataTextField(dataTextField)
                .DataValueField(dataValueField)
                .Filter(FilterType.Contains)
                .Events(e => e.Change("OnKendoMultiSelectChange").Select("OnKendoMultiSelectSelect"))
                .DataSource(source =>
                {
                    source.Read(read =>
                    {
                        read.Action(actionName, controlerName);//, new { _controlType = 2, _controlName = name } //Set the Action and Controller names.
                    });
                    // .ServerFiltering(false); //If true, the DataSource will not filter the data on the client.
                });
        }

        public static Kendo.Mvc.UI.Fluent.MultiSelectBuilder
       KendoMultiSelect(this HtmlHelper helper, string name, string[] forval, string dataTextField, string dataValueField,
         string controlerName, string actionName, string htmlStyle = "")
        {
            if (string.IsNullOrEmpty(htmlStyle)) htmlStyle = "width: 100%";
            return helper.Kendo().MultiSelect()
                .Name(name)
                .Value(forval)
                .HtmlAttributes(new { style = htmlStyle })
                .DataTextField(dataTextField)
                .DataValueField(dataValueField)
                .Filter(FilterType.Contains)

                .Events(e => e.Change("OnKendoMultiSelectChange").Select("OnKendoMultiSelectSelect"))

                .DataSource(source =>
                {
                    source.Read(read =>
                    {
                        read.Action(actionName, controlerName);
                    });

                });
        }

        public static Kendo.Mvc.UI.Fluent.UploadBuilder
          KendoUpload(this HtmlHelper helper, string name, string controler, bool isMultiple = true, string htmlStyle = "")
        {
            if (string.IsNullOrEmpty(htmlStyle)) htmlStyle = "width: 100%;height:150px;";
            return helper.Kendo().Upload()
                .Name("files")
                .HtmlAttributes(new { style = htmlStyle })
                .Async(async => async
                    .Save("SaveFile", controler)
                    .Remove("RemoveFile", controler)
                    .AutoUpload(true)
                )
                .Multiple(isMultiple);
        }

        public static Kendo.Mvc.UI.Fluent.ListViewBuilder<T>
          ChackBoxList<T>(this HtmlHelper helper, string name, string template, string controlerName, string actionName,
                           string htmlStyle = "", string Parm = "") where T : class
        {
            return helper.Kendo().ListView<T>()
                       .Name(name)
                       .TagName("div")
                       .ClientTemplateId(template)
                       .HtmlAttributes(new { style = htmlStyle })
                       .DataSource(dataSource =>
                       {
                           dataSource.Read(read => read.Action(actionName, controlerName));
                           dataSource.ServerOperation(false);
                       })
                       .Selectable(selectable => selectable.Mode(ListViewSelectionMode.Single));
        }

        public static Kendo.Mvc.UI.Fluent.ListViewBuilder<T>
          OptionButtonList<T>(this HtmlHelper helper, string name, string template, string controlerName, string actionName,
                           string htmlStyle = "", string Parm = "") where T : class
        {
            return helper.Kendo().ListView<T>()
                .Name(name)
                .TagName("div")
                .ClientTemplateId(template)
                .HtmlAttributes(new { style = htmlStyle })
                .DataSource(dataSource =>
                {
                    dataSource.Read(read => read.Action(actionName, controlerName));
                    dataSource.ServerOperation(false);
                })
                .Selectable(selectable => selectable.Mode(ListViewSelectionMode.Single));
        }

        public static MvcHtmlString EncodedActionLink(this HtmlHelper htmlHelper, string linkText, string actionName,
      string controllerName, object routeValues, object htmlAttributes)
        {
            string queryString = string.Empty;
            string htmlAttributesString = string.Empty;
            if (routeValues != null)
            {
                RouteValueDictionary d = new RouteValueDictionary(routeValues);
                for (int i = 0; i < d.Keys.Count; i++)
                {
                    if (i > 0)
                    {
                        queryString += "?";
                    }
                    queryString += d.Keys.ElementAt(i) + "=" + d.Values.ElementAt(i);
                }
            }

            if (htmlAttributes != null)
            {
                RouteValueDictionary d = new RouteValueDictionary(htmlAttributes);
                for (int i = 0; i < d.Keys.Count; i++)
                {
                    htmlAttributesString += " " + d.Keys.ElementAt(i) + "=" + "\"" + d.Values.ElementAt(i) + "\"";
                }
            }

            //What is Entity Framework??
            StringBuilder ancor = new StringBuilder();
            ancor.Append("<a ");
            if (htmlAttributesString != string.Empty)
            {
                ancor.Append(htmlAttributesString);
            }
            ancor.Append(" href='");
            if (controllerName != string.Empty)
            {
                ancor.Append("/" + controllerName);
            }

            if (actionName != "Index")
            {
                ancor.Append("/" + actionName);
            }
            if (queryString != string.Empty)
            {
                ancor.Append("?q=" + Encrypt(queryString));
            }
            ancor.Append("'");
            ancor.Append(">");
            ancor.Append(linkText);
            ancor.Append("</a>");
            return new MvcHtmlString(ancor.ToString());
        }

        private static string Encrypt(string plainText)
        {
            try
            {
                string Password = "jdsg432387#";
                RijndaelManaged RijndaelCipher = new RijndaelManaged();
                byte[] PlainText = System.Text.Encoding.Unicode.GetBytes(plainText);
                byte[] Salt = Encoding.ASCII.GetBytes(Password.Length.ToString());
                PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(Password, Salt);
                ICryptoTransform Encryptor = RijndaelCipher.CreateEncryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, Encryptor, CryptoStreamMode.Write);
                cryptoStream.Write(PlainText, 0, PlainText.Length);
                cryptoStream.FlushFinalBlock();
                byte[] CipherBytes = memoryStream.ToArray();
                memoryStream.Close();
                cryptoStream.Close();
                string EncryptedData = Convert.ToBase64String(CipherBytes);
                return EncryptedData.Replace("+", "-").Replace("/", "_");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string ActionLinkWithList(this HtmlHelper helper, string action, string controller, object routeData, object htmlAttributes)
        {
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);


            string href = urlHelper.Action(action, controller);

            if (routeData != null)
            {
                RouteValueDictionary rv = new RouteValueDictionary(routeData);
                List<string> urlParameters = new List<string>();
                foreach (var key in rv.Keys)
                {
                    object value = rv[key];

                    if (key == "geogFocusID" || key == "docTypeID" || key == "themeID" || key == "subThemeID")
                    {
                        value = rv[key];
                        var valArray = GetStringToArray(value.ToString());
                        foreach (var item in valArray)
                        {
                            value = item;
                            if (value is IEnumerable && !(value is string))
                            {
                                int i = 0;
                                foreach (object val in (IEnumerable)value)
                                {
                                    urlParameters.Add(string.Format("{0}[{2}]={1}", key, val, i));
                                    ++i;
                                }
                            }
                            else if (value != null)
                            {
                                urlParameters.Add(string.Format("{0}={1}", key, value));
                            }
                        }

                    }
                    else
                    {
                        if (value is IEnumerable && !(value is string))
                        {
                            int i = 0;
                            foreach (object val in (IEnumerable)value)
                            {
                                urlParameters.Add(string.Format("{0}[{2}]={1}", key, val, i));
                                ++i;
                            }
                        }
                        else if (value != null)
                        {
                            urlParameters.Add(string.Format("{0}={1}", key, value));
                        }
                    }
                }
                string paramString = string.Join("&", urlParameters.ToArray()); // ToArray not needed in 4.0
                if (!string.IsNullOrEmpty(paramString))
                {
                    href += "?" + paramString;
                }
            }



            return href;
        }
        private static string[] GetStringToArray(string sourceArray)
        {
            int total = 0;
            StringBuilder totalString = new StringBuilder();
            string[] ExpectedArray = new string[total];
            if (sourceArray != null && sourceArray != "")
            {

                totalString.Append(sourceArray);

                totalString.Replace(totalString.ToString(), totalString.ToString().Replace('\\', ' ').ToString());
                ExpectedArray = totalString.ToString().Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries);

            }
            return ExpectedArray;
        }

    }
}

//Multi Select

//Button Group
//Tab Strip
//Tree View