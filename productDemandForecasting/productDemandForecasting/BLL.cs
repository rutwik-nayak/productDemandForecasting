using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using productDemandForecasting.DLTableAdapters;

namespace productDemandForecasting
{
    //business logic layer which contains all functionalities related to the project
    public class BLL
    {
        tblAdminTableAdapter adminObj = new tblAdminTableAdapter();
        tblCompaniesTableAdapter companyObj = new tblCompaniesTableAdapter();
        tblCustomersTableAdapter customerObj = new tblCustomersTableAdapter();
        tblCategoriesTableAdapter categoryObj = new tblCategoriesTableAdapter();
        tblFeaturesTableAdapter featureObj = new tblFeaturesTableAdapter();
        tblFeatureValuesTableAdapter valueObj = new tblFeatureValuesTableAdapter();
        tblProductsTableAdapter productObj = new tblProductsTableAdapter();
        tblProductFeaturesTableAdapter productfeatureObj = new tblProductFeaturesTableAdapter();
        tblQueriesTableAdapter queryObj = new tblQueriesTableAdapter();
        tblRatingsTableAdapter ratingObj = new tblRatingsTableAdapter();
        tblTopicsTableAdapter topicObj = new tblTopicsTableAdapter();
        tblCommentsTableAdapter commentObj = new tblCommentsTableAdapter();

        //inner join
        tblCategoriestblFeaturesTableAdapter categoryFeatureObj = new tblCategoriestblFeaturesTableAdapter();
        tblCategoriestblProductsTableAdapter categoryProductObj = new tblCategoriestblProductsTableAdapter();
        tblCompaniestblCategoriestblProductsTableAdapter compCategProductObj = new tblCompaniestblCategoriestblProductsTableAdapter();
               
        #region *************** ADMINISTRATOR *****************
              
        //function to retreive the company details by id
        public DataTable GetCompanyById(string companyId)
        {
            return companyObj.GetCompanyById(companyId);
        }

        //function to approve the company registration
        public void CompanyApproval(string status, string companyId)
        {
            companyObj.UpdateStatus(status, companyId);
        }

        //function to reject or delete the company registration details
        public void DeleteCompany(string companyId)
        {
            companyObj.DeleteCompany(companyId);
        }

        //function to retrive the registered customers
        public DataTable GetAllCustomers()
        {
            return customerObj.GetData();
        }

        //function to delete the customer registration details
        public void DeleteCustomer(string custId)
        {
            customerObj.DeleteCustomer(custId);
        }

        //function to get the admin by admin id
        public DataTable GetAdminById(string adminId)
        {
            return adminObj.GetAdminById(adminId);
        }

        //function to change the password of admin
        public void AdminChangePassword(string adminId, string password)
        {
            adminObj.UpdateAdminPassword(password, adminId);
        }

        //function to insert new topic
        public void InsertTopic(string companyId, string topic, DateTime postedDate)
        {
            topicObj.InsertTopic(companyId, topic, postedDate);
        }

        //function to get topic based on id
        public DataTable GetTopicById(int topicId)
        {
            return topicObj.GetTopicById(topicId);
        }

        //function to get all topics
        public DataTable GetAllTopics()
        {
            return topicObj.GetData();
        }

        //function to get topics based on company id
        public DataTable GetTopicsByCompanyId(string companyId)
        {
            return topicObj.GetTopicsByCompanyId(companyId);
        }

        //function to delete the topic
        public void DeleteTopic(int topicId)
        {
            topicObj.DeleteTopic(topicId);
        }

        //function to insert new comment
        public void InsertComment(string companyId, int topicId, string comment, DateTime date)
        {
            commentObj.InsertComment(topicId, companyId, comment, date);
        }

        //function to get comment based on id
        public DataTable GetCommentById(int commentId)
        {
            return commentObj.GetCommentById(commentId);
        }

        //function to delete comment
        public void DeleteComment(int commentId)
        {
            commentObj.DeleteComment(commentId);
        }

        //function to delete topic comments
        public void DeleteTopicComments(int topicId)
        {
            commentObj.DeleteTopicComments(topicId);
        }

        //function to get topic comments
        public DataTable GetTopicComments(int topicId)
        {
            return commentObj.GetTopicComments(topicId);
        }

        //function to delete company comments
        public void DeleteCompanyComments(string companyId)
        {
            commentObj.DeleteCompanyComments(companyId);
        }

        //function to delete company topics
        public void DeleteCompanyTopics(string companyId)
        {
            topicObj.DeleteCompanyTopics(companyId);
        }

        //function to retrive all queries
        public DataTable GetAllQueries()
        {
            return queryObj.GetData();
        }

        //function to retrive pending queries
        public DataTable GetPendingQueries()
        {
            return queryObj.GetPendingQueries();
        }

        //function to retrive answered queries
        public DataTable GetAnsweredQueries()
        {
            return queryObj.GetAnsweredQueries();
        }

        //function to retrive company queries
        public DataTable GetQueriesByCompany(string companyId)
        {
            return queryObj.GetQueriesByCompany(companyId);
        }

        //function to retrive company pending queries
        public DataTable GetPendingQueriesByCompany(string companyId)
        {
            return queryObj.GetPendingQueriesByCompany(companyId);
        }

        //function to retrive company answered queries
        public DataTable GetAnsweredQueriesByCompany(string companyId)
        {
            return queryObj.GetAnsweredQueriesByCompany(companyId);
        }

        //function to insert new query
        public void InsertNewQuery(string companyId, string query, DateTime date)
        {
            queryObj.InsertQuery(companyId, query, date);
        }

        //function to delete the company queries
        public void DeleteQueriesByCompany(string companyId)
        {
            queryObj.DeleteQueriesByCompany(companyId);
        }

        //function to delete the customer ratings
        public void DeleteCustomerRatings(string customerId)
        {
            ratingObj.DeleteCustomerRatings(customerId);
        }

        //function to delete the product ratings
        public void DeleteProductRatings(int productId)
        {
            ratingObj.DeleteProductRatings(productId);
        }

        //function to retrive the comments based on company
        public DataTable GetCommentsByCompany(string companyId)
        {
            return commentObj.GetCommentsByCompany(companyId);
        }

        //function to delete the query based in id
        public void DeleteQuery(int queryId)
        {
            queryObj.DeleteQuery(queryId);
        }

        //function to get query by id
        public DataTable GetQueryById(int queryId)
        {
            return queryObj.GetQueryById(queryId);
        }

        //function to send reply
        public void SendReply(string reply, DateTime date, int queryId)
        {
            queryObj.ReplyQuery(reply, date, queryId);
        }

        #endregion

        #region *************** COMPANY *****************

        //function to update the company profile
        public void UpdateCompanyProfile(string address, string city, string contactNo, string emailId, string websiteAddress, string logo,string companyId)
        {
            companyObj.UpdateCompany(address, city, contactNo, emailId, websiteAddress, logo, companyId);
        }

        //function to insert new category
        public void InsertCategory(string companyId, string categoryName)
        {
            categoryObj.InsertCategory(companyId, categoryName);
        }

        //function to delete the category
        public void DeleteCategory(int categoryId)
        {
            categoryObj.DeleteCategory(categoryId);
        }

        //function to delete the categories by company
        public void DeleteCategoriesByCompany(string companyId)
        {
            categoryObj.DeleteCategoriesByCompany(companyId);
        }
               
        //function to get category by id
        public DataTable GetCategoryById(int categoryId)
        {
            return categoryObj.GetCategoryById(categoryId);
        }

        //function to check the categoryName
        public bool CheckCategoryName(string companyId, string categoryName)
        {
            int cnt = int.Parse(categoryObj.CheckCompanyCategoryName(companyId, categoryName).ToString());

            if (cnt == 1)

                return false;

            return true;
        }

        //function to insert new feature
        public void InsertFeature(int categoryId, string Feature)
        {
            featureObj.InsertFeature(categoryId, Feature);
        }

        //function to delete the feature
        public void DeleteFeature(int featureId)
        {
            featureObj.DeleteFeature(featureId);
        }

        //function to delete the features by category
        public void DeleteFeaturesByCategory(int categoryId)
        {
            featureObj.DeleteFeaturesByCategory(categoryId);
        }

        //function to get features by category
        public DataTable GetFeaturesByCategory(int categoryId)
        {
            return featureObj.GetFeaturesByCategory(categoryId);
        }

        //function to get feature by id
        public DataTable GetFeatureById(int featureId)
        {
            return featureObj.GetFeatureById(featureId);
        }

        //function to retrive features based on company
        public DataTable GetFeaturesByCompany(string companyId)
        {
            return categoryFeatureObj.GetCompanyFeatures(companyId);
        }

        //function to check the featureName
        public bool CheckFeatureName(string companyId, int categoryId, string feature)
        {
            int cnt = int.Parse(categoryFeatureObj.CheckFeatureName(companyId, categoryId, feature).ToString());

            if (cnt == 1)

                return false;

            return true;
        }

        //function to update the feature
        public void UpdateFeature(int categoryId, string feature, int featureId)
        {
            featureObj.UpdateFeature(categoryId, feature, featureId);
        }

        //function to insert the feature value
        public void InsertValue(int featureId, string value)
        {
            valueObj.InsertValue(featureId, value);
        }

        //function to get the value by id
        public DataTable GetValueById(int valueId)
        {
            return valueObj.GetValueById(valueId);
        }

        //function to get the values by feature
        public DataTable GetValuesByFeature(int featureId)
        {
            return valueObj.GetValuesByFeature(featureId);
        }

        //function to delete the value
        public void DeleteValue(int valueId)
        {
            valueObj.DeleteValue(valueId);
        }

        //function to delete the feature values
        public void DeleteValuesByFeature(int featureId)
        {
            valueObj.DeleteValuesByFeature(featureId);
        }

        //function to check the value name
        public bool CheckValueName(int featureId, string value)
        {
            int cnt = int.Parse(valueObj.CheckValueByFeature(featureId, value).ToString());

            if (cnt == 1)

                return false;

            return true;
        }

        //function to insert the new product
        public void InsertProduct(int categoryId, string productName, string description, float cost, string photo, float investment, int soldQuantity, string profit, DateTime date,float actualCost,int stockQty)
        {
            productObj.InsertProduct(categoryId, productName, description, cost,actualCost, photo, investment,stockQty, soldQuantity, profit, date);
        }

        //function to update the product
        public void UpdateProduct(int categoryId, string productName, string description, float cost, string photo, float investment, int soldQuantity, string profit,
            DateTime date, int productId, float actualCost, int stockQty)
        {
            productObj.UpdateProduct(categoryId, productName, description, cost, actualCost, photo, investment, stockQty, soldQuantity, profit, date, productId);
        }

        //function to delete the product
        public void DeleteProduct(int productId)
        {
            productObj.DeleteProduct(productId);
        }

        //function to retrive the company products
        public DataTable GetProductsByCompany(string companyId)
        {
            return categoryProductObj.GetCompanyProducts(companyId);
        }

        //function to retrive all products[count]
        public DataTable GetAllProducts()
        {
            return productObj.GetData();
        }

        //function to get the max of product id
        public int GetMaxProductId()
        {
            int cnt = int.Parse(productObj.GetMaxofProductId().ToString());
            return cnt;
        }

        //function to delete the products by category
        public void DeleteProductsByCategory(int categoryId)
        {
            productObj.DeleteProductsByCategory(categoryId);
        }

        //function to get the product by id
        public DataTable GetProductById(int productId)
        {
            return productObj.GetProductById(productId);
        }

        //function to get the products by category
        public DataTable GetProductsByCategory(int categoryId)
        {
            return productObj.GetProductsByCategory(categoryId);
        }

        //function to check the product name
        public bool CheckProductName(int categoryId, string productName)
        {
            int cnt = int.Parse(productObj.CheckProductNameByCategory(categoryId, productName).ToString());

            if (cnt == 1)

                return false;

            return true;

        }

        //function to insert the product feature
        public void InsertProductFeature(int productId, int valueId)
        {
            productfeatureObj.InsertProductFeature(productId, valueId);
        }

        //function to delete the product features
        public void DeleteProductFeatures(int productId)
        {
            productfeatureObj.DeleteProductFeatures(productId);
        }

        //function to delete the product feature
        public void DeleteProductFeature(int PFId)
        {
            productfeatureObj.DeleteProductFeature(PFId);
        }

        //function to update the company password
        public void UpdateComanyPassword(string password, string companyId)
        {
            companyObj.UpdatePassword(password, companyId);
        }

        //function to get the product ratings
        public int GetProductRatings(int productId)
        {
            return (int)ratingObj.GetProductRatingSum(productId);
        }
         
        //function to get the ratings based on product
        public DataTable GetRatingsByProduct(int productId)
        {
            return ratingObj.GetRatingsByProduct(productId);
        }

        //function to get the products based on categoryId and product id
        public DataTable GetProductsByCategory_Id(int categoryId, int productId)
        {
            return productObj.GetProductsByCategory_ID(categoryId, productId);
        }

        #endregion

        #region ********** CUSTOMER **************

        //function to get customer by id
        public DataTable GetCustomerById(string customerId)
        {
            return customerObj.GetCustomerById(customerId);
        }

        //function to update the customer profile
        public void UpdateCustomer(string fName, string lName, string mobile, string emailId, string custId)
        {
            customerObj.UpdateCustomer(fName, lName, mobile, emailId, custId);
        }

        //function to update the customer password
        public void UpdateCustomerPassword(string custId, string password)
        {
            customerObj.UpdateCustomerPassword(custId, password);
        }
                
        //function to retrive categories by company
        public DataTable GetCategoriesByCompany(string companyId)
        {
            return categoryObj.GetCategoriesByCompany(companyId);
        }
               
        //function to retrive product details by product id
        public DataTable GetProductsById(int productId)
        {
            return productObj.GetProductById(productId);
        }

        //function to retrive the product features and thier values
        public DataTable GetProductFeatures(int productId)
        {
            return productfeatureObj.GetFeaturesByProduct(productId);
        }

        //function to retrive the products based on company id and category id
        public DataTable GetProductsByCompanyIdandCategoryId(string companyId, int categoryId)
        {
            return compCategProductObj.GetProductsByCompanyandCategory(companyId, categoryId);
        }

        //function to get the customer rating
        public DataTable GetCustomerRating(string customerId)
        {
            return ratingObj.GetRatingByCustomer(customerId);
        }

        //functiont to delete the rating
        public void DeleteRating(int ratingId)
        {
            ratingObj.DeleteRating(ratingId);
        }

        //function to insert the customer rating
        public void InsertRating(string customerId, int productId, int rating, DateTime date)
        {
            ratingObj.InsertRating(customerId, productId, rating, date);
        }

        //function to delete the customer ratings
        public void DeleteRatingsByCustomer(string customerId)
        {
            ratingObj.DeleteCustomerRatings(customerId);
        }

        //function to check the customer rating
        public DataTable CheckCustomerRating(string customerId, int productId)
        {
            return ratingObj.CheckCustomerRating(customerId, productId);
        }

        #endregion

        #region *************** GUEST *****************

        //function to check the admin login
        public bool CheckAdminLogin(string adminId, string password)
        {
            int cnt = int.Parse(adminObj.CheckAdminLogin(adminId, password).ToString());

            if (cnt == 1)

                return true;

            return false;
        }

        //function to check the company id
        public bool CheckCompanyId(string companyId)
        {
            int cnt = int.Parse(companyObj.CheckCompanyId(companyId).ToString());

            if (cnt == 1)

                return false;

            return true;
        }

        //function to check the company login
        public bool CheckCompanyLogin(string companyId, string password)
        {
            int cnt = int.Parse(companyObj.CheckCompanyLogin(companyId, password).ToString());

            if (cnt == 1)

                return true;

            return false;
        }

        //function for the company registration
        public void InsertCompany(string companyId, string pwd, string companyName, string address, string city, string contactNo, string emailId, string websiteAddress,
            string logo, string receiptNumber, DateTime registeredDate, string status)
        {
            companyObj.InsertCompany(companyId, pwd, companyName, address, city, contactNo, emailId, websiteAddress, logo, receiptNumber, registeredDate, status);
        }

        //function to retrive all members or companies based on status
        public DataTable GetCompaniesByStatus(string status)
        {
            return companyObj.GetCompaniesByStatus(status);
        }

        //function to get register as a customer
        public void InsertCustomer(string customerId, string password, string fName, string lName, string mobile, string emailId, DateTime date)
        {
            customerObj.InsertCustomer(customerId, password, fName, lName, mobile, emailId, date);
        }

        //function to check the customer id
        public bool CheckCustomerId(string customerId)
        {
            int cnt = int.Parse(customerObj.CheckCustomerId(customerId).ToString());

            if (cnt == 1)

                return false;

            return true;
        }

        //function to check the customer login
        public bool CheckCustomerLogin(string customerId, string password)
        {
            int cnt = int.Parse(customerObj.CheckCustomerLogin(customerId,password).ToString());

            if (cnt == 1)

                return true;

            return false;
        }
 
        #endregion

    }
}