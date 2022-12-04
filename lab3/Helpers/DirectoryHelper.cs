using System.Web.Mvc;
using DictionaryLibrary;

namespace lab3.Helpers
{
    public static class DirectoryHelper
    {
        public static MvcHtmlString AddPhoneForm(this HtmlHelper html)
        {
            TagBuilder form = new TagBuilder("form");
            form.MergeAttribute("method", "post");
            form.MergeAttribute("action", "/Dictionary/AddSave");
            form.MergeAttribute("style", "margin-top: 10px");

            TagBuilder phoneInputWrapper = new TagBuilder("div");
            phoneInputWrapper.MergeAttribute("style", "margin-bottom: 5px");
            TagBuilder phoneInput = new TagBuilder("input");
            phoneInput.MergeAttribute("class", "form-control");
            phoneInput.MergeAttribute("type", "text");
            phoneInput.MergeAttribute("name", "PhoneNumber");
            phoneInput.MergeAttribute("placeholder", "PhoneNumber");
            phoneInputWrapper.InnerHtml = phoneInput.ToString();

            TagBuilder nameInputWrapper = new TagBuilder("div");
            nameInputWrapper.MergeAttribute("style", "margin-bottom: 5px");
            TagBuilder nameInput = new TagBuilder("input");
            nameInput.MergeAttribute("class", "form-control");
            nameInput.MergeAttribute("type", "text");
            nameInput.MergeAttribute("name", "UserSurname");
            nameInput.MergeAttribute("placeholder", "Surname");
            nameInputWrapper.InnerHtml = nameInput.ToString();

            TagBuilder submitButtonWrapper = new TagBuilder("div");
            TagBuilder submitButton = new TagBuilder("button");
            submitButton.MergeAttribute("type", "submit");
            submitButton.SetInnerText("Add");
            submitButtonWrapper.InnerHtml = submitButton.ToString();

            form.InnerHtml = phoneInputWrapper.ToString() + nameInputWrapper.ToString() + submitButtonWrapper.ToString();
            return new MvcHtmlString(form.ToString());
        }

        public static MvcHtmlString UpdatePhoneForm(this HtmlHelper html,object newDictionaryItem)
        {
            DictionaryItem dictionaryItem = newDictionaryItem as DictionaryItem;
            TagBuilder form = new TagBuilder("form");
            form.MergeAttribute("method", "post");
            form.MergeAttribute("action", "/Dictionary/UpdateSave");
            form.MergeAttribute("style", "margin-top: 10px");
            
            TagBuilder idInput = new TagBuilder("input");
            idInput.MergeAttribute("hidden", "hidden");
            idInput.MergeAttribute("name", "UserId");
            idInput.MergeAttribute("value", dictionaryItem.UserId.ToString());


            TagBuilder nameInputWrapper = new TagBuilder("div");
            TagBuilder NameInput = new TagBuilder("input");
            nameInputWrapper.MergeAttribute("style", "margin-bottom: 5px");
            NameInput.MergeAttribute("class", "form-control");
            NameInput.MergeAttribute("type", "text");
            NameInput.MergeAttribute("name", "UserSurname");
            NameInput.MergeAttribute("value", dictionaryItem.UserSurname);
            // NameInput.MergeAttribute("placeholder", "Surname");
            nameInputWrapper.InnerHtml = NameInput.ToString();

            TagBuilder phoneInputWrapper = new TagBuilder("div");
            TagBuilder phoneInput = new TagBuilder("input");
            phoneInputWrapper.MergeAttribute("style", "margin-bottom: 5px");
            phoneInput.MergeAttribute("class", "form-control");
            phoneInput.MergeAttribute("type", "number");
            phoneInput.MergeAttribute("name", "PhoneNumber");
            phoneInput.MergeAttribute("value", dictionaryItem.PhoneNumber.ToString());
            // phoneInput.MergeAttribute("placeholder", "Phone Number");
            phoneInputWrapper.InnerHtml = phoneInput.ToString();

            TagBuilder submitButtonWrapper = new TagBuilder("div");
            TagBuilder submitButton = new TagBuilder("button");
            submitButton.MergeAttribute("type", "submit");
            submitButton.SetInnerText("Обновить");
            submitButtonWrapper.InnerHtml = submitButton.ToString();

            
            form.InnerHtml = idInput.ToString() + nameInputWrapper.ToString() + phoneInputWrapper.ToString() + submitButtonWrapper.ToString();
            return new MvcHtmlString(form.ToString());
        }
    }
}