using Google.Api.Ads.AdWords.Lib;
using Google.Api.Ads.AdWords.v201309;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleAdword
{
    public class GoogleServices
    {
        //public string[] RunTargetIdea(AdWordsUser user, string[] keywordLine)
        //{
        //    // Get the TargetingIdeaService.
        //    TargetingIdeaService targetingIdeaService =
        //        (TargetingIdeaService)user.GetService(AdWordsService.v201309.TargetingIdeaService);

        //    // Create selector.
        //    TargetingIdeaSelector selector = new TargetingIdeaSelector();
        //    selector.requestType = RequestType.IDEAS;
        //    selector.ideaType = IdeaType.KEYWORD;
        //    selector.requestedAttributeTypes = new AttributeType[] {
        //      AttributeType.KEYWORD_TEXT,
        //      //AttributeType.SEARCH_VOLUME,
        //      //AttributeType.CATEGORY_PRODUCTS_AND_SERVICES
        //    };
        //    // Language setting (optional).
        //    // The ID can be found in the documentation:
        //    //   https://developers.google.com/adwords/api/docs/appendix/languagecodes
        //    // Note: As of v201302, only a single language parameter is allowed.
        //    LanguageSearchParameter languageParameter = new LanguageSearchParameter();
        //    Language english = new Language();
        //    english.id = 1000;
        //    languageParameter.languages = new Language[] { english };

        //    // Create related to query search parameter.
        //    RelatedToQuerySearchParameter relatedToQuerySearchParameter =
        //        new RelatedToQuerySearchParameter();
        //    relatedToQuerySearchParameter.queries = new String[keywordLine.Length];
        //    for (int i = 0; i < keywordLine.Length; i++)
        //    {
        //        string keywordText = keywordLine[i];
        //        relatedToQuerySearchParameter.queries[i] = keywordText;
        //    }

        //    selector.searchParameters =
        //      new SearchParameter[] { relatedToQuerySearchParameter, languageParameter };

        //    // Set selector paging (required for targeting idea service).
        //    Paging paging = new Paging();
        //    paging.startIndex = 0;
        //    paging.numberResults = 50;
        //    selector.paging = paging;

        //    int offset = 0;
        //    int pageSize = 50;

        //    TargetingIdeaPage page = new TargetingIdeaPage();
        //    int j = 0;
        //    String[] arrKeyWord = new String[800];
        //    try
        //    {
        //        do
        //        {

        //            selector.paging.startIndex = offset;
        //            selector.paging.numberResults = pageSize;
        //            // Get related keywords.
        //            page = targetingIdeaService.get(selector);

        //            // Display related keywords.
        //            if (page.entries != null && page.entries.Length > 0)
        //            {
        //                int i = offset;
        //                foreach (TargetingIdea targetingIdea in page.entries)
        //                {
        //                    string keyword = null;
        //                    string categories = null;
        //                    long averageMonthlySearches = 0;

        //                    foreach (Type_AttributeMapEntry entry in targetingIdea.data)
        //                    {
        //                        if (entry.key == AttributeType.KEYWORD_TEXT)
        //                        {
        //                            keyword = (entry.value as StringAttribute).value;
        //                            arrKeyWord[j] = keyword;
        //                        }
        //                        if (entry.key == AttributeType.CATEGORY_PRODUCTS_AND_SERVICES)
        //                        {
        //                            IntegerSetAttribute categorySet = entry.value as IntegerSetAttribute;
        //                            StringBuilder builder = new StringBuilder();
        //                            if (categorySet.value != null)
        //                            {
        //                                foreach (int value in categorySet.value)
        //                                {
        //                                    builder.AppendFormat("{0}, ", value);
        //                                }
        //                                categories = builder.ToString().Trim(new char[] { ',', ' ' });
                          
        //                            }
        //                        }
        //                        if (entry.key == AttributeType.SEARCH_VOLUME)
        //                        {
        //                            averageMonthlySearches = (entry.value as LongAttribute).value;
        //                        }
        //                    }
        //                    Console.WriteLine("Keyword with text '{0}' was found", keyword);
        //                    i++;
        //                    j++;
        //                }

        //            }
        //            offset += pageSize;
        //        } while (offset < page.totalNumEntries);
        //        Console.WriteLine("Number of related keywords found: {0}", page.totalNumEntries);
        //        return arrKeyWord;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new System.ApplicationException("Failed to retrieve related keywords.", ex);
        //    }
        //}

        public string RunTargetIdea(AdWordsUser user, string[] keywordLine)
        {
            // Get the TargetingIdeaService.
            TargetingIdeaService targetingIdeaService =
                (TargetingIdeaService)user.GetService(AdWordsService.v201309.TargetingIdeaService);

           // string keywordText = "mars cruise";

            // Create selector.
            TargetingIdeaSelector selector = new TargetingIdeaSelector();
            selector.requestType = RequestType.IDEAS;
            selector.ideaType = IdeaType.KEYWORD;
            selector.requestedAttributeTypes = new AttributeType[] {
        AttributeType.KEYWORD_TEXT,
        AttributeType.SEARCH_VOLUME,
        AttributeType.CATEGORY_PRODUCTS_AND_SERVICES};

            // Language setting (optional).
            // The ID can be found in the documentation:
            //   https://developers.google.com/adwords/api/docs/appendix/languagecodes
            // Note: As of v201302, only a single language parameter is allowed.
            LanguageSearchParameter languageParameter = new LanguageSearchParameter();
            Language english = new Language();
            english.id = 1000;
            languageParameter.languages = new Language[] { english };

            // Create related to query search parameter.
            RelatedToQuerySearchParameter relatedToQuerySearchParameter =
                new RelatedToQuerySearchParameter();

            relatedToQuerySearchParameter.queries = new String[keywordLine.Length];
            for (int i = 0; i < keywordLine.Length; i++)
            {
                string keywordText = keywordLine[i];
                relatedToQuerySearchParameter.queries[i] = keywordText;
            }

            //relatedToQuerySearchParameter.queries = new String[] { keywordText };
            selector.searchParameters =
              new SearchParameter[] { relatedToQuerySearchParameter, languageParameter };


            // Set selector paging (required for targeting idea service).
            Paging paging = new Paging();
            paging.startIndex = 0;
            paging.numberResults = 500;
            selector.paging = paging;

            int offset = 0;
            int pageSize = 500;

            TargetingIdeaPage page = new TargetingIdeaPage();
            int j = 0;
            String[] arrKeyWord = new String[800];
            String[] arrSearchVolume = new String[800];
            String[] arrKeywordCategory = new String[800];
            try
            {
                do
                {
                    selector.paging.startIndex = offset;
                    selector.paging.numberResults = pageSize;
                    // Get related keywords.
                    page = targetingIdeaService.get(selector);

                    // Display related keywords.
                    if (page.entries != null && page.entries.Length > 0)
                    {
                        int i = offset;
                        foreach (TargetingIdea targetingIdea in page.entries)
                        {
                            string keyword = null;
                            string categories = null;
                            long averageMonthlySearches = 0;

                            foreach (Type_AttributeMapEntry entry in targetingIdea.data)
                            {
                                if (entry.key == AttributeType.KEYWORD_TEXT)
                                {
                                    keyword = (entry.value as StringAttribute).value;
                                    arrKeyWord[j] = keyword;
                                }
                                if (entry.key == AttributeType.CATEGORY_PRODUCTS_AND_SERVICES)
                                {
                                    IntegerSetAttribute categorySet = entry.value as IntegerSetAttribute;
                                    StringBuilder builder = new StringBuilder();
                                    if (categorySet.value != null)
                                    {
                                        foreach (int value in categorySet.value)
                                        {
                                            builder.AppendFormat("{0}, ", value);
                                        }
                                        categories = builder.ToString().Trim(new char[] { ',', ' ' });
                                        arrKeywordCategory[j] = categories;
                                    }
                                }
                                if (entry.key == AttributeType.SEARCH_VOLUME)
                                {
                                    averageMonthlySearches = (entry.value as LongAttribute).value;
                                    arrSearchVolume[j] = Convert.ToString(averageMonthlySearches);
                                }
                            }
                            Console.WriteLine("Keyword with text '{0}', and average monthly search volume " +
                                "'{1}' was found with categories: {2}", keyword, averageMonthlySearches,
                                categories);
                            i++;
                            j++;
                        }
                    }
                    offset += pageSize;
                } while (offset < page.totalNumEntries);
                Console.WriteLine("Number of related keywords found: {0}", page.totalNumEntries);
                string strKeyword = String.Join("_" , arrKeyWord);
                string strSearchVolume = String.Join("_" , arrSearchVolume);
                string strKeywordCategory = String.Join("_", arrKeywordCategory);
                string strReturn = strKeyword + "|" + strSearchVolume + "|" + strKeywordCategory;
                return strReturn;
            }
            catch (Exception ex)
            {
                throw new System.ApplicationException("Failed to retrieve related keywords.", ex);
            }
        }
     public void RunEstimatorService(AdWordsUser user , string Broad)
        {
            // Get the TrafficEstimatorService.
            TrafficEstimatorService trafficEstimatorService = (TrafficEstimatorService)user.GetService(
                AdWordsService.v201309.TrafficEstimatorService);

            // Create keywords. Up to 2000 keywords can be passed in a single request.
            Keyword keyword1 = new Keyword();
            keyword1.text = Broad;
            keyword1.matchType = KeywordMatchType.BROAD;

            Keyword keyword2 = new Keyword();
            keyword2.text = "cruise";
            keyword2.matchType = KeywordMatchType.PHRASE;

            Keyword keyword3 = new Keyword();
            keyword3.text = "mars";
            keyword3.matchType = KeywordMatchType.EXACT;

            Keyword[] keywords = new Keyword[] {keyword1,keyword2,keyword3};

            // Create a keyword estimate request for each keyword.
            List<KeywordEstimateRequest> keywordEstimateRequests = new List<KeywordEstimateRequest>();

            foreach (Keyword keyword in keywords)
            {
                KeywordEstimateRequest keywordEstimateRequest = new KeywordEstimateRequest();
                keywordEstimateRequest.keyword = keyword;
                keywordEstimateRequests.Add(keywordEstimateRequest);
            }

            // Create negative keywords.
            Keyword negativeKeyword1 = new Keyword();
            negativeKeyword1.text = "moon walk";
            negativeKeyword1.matchType = KeywordMatchType.BROAD;

            KeywordEstimateRequest negativeKeywordEstimateRequest = new KeywordEstimateRequest();
            negativeKeywordEstimateRequest.keyword = negativeKeyword1;
            negativeKeywordEstimateRequest.isNegative = true;
            keywordEstimateRequests.Add(negativeKeywordEstimateRequest);

            // Create ad group estimate requests.
            AdGroupEstimateRequest adGroupEstimateRequest = new AdGroupEstimateRequest();
            adGroupEstimateRequest.keywordEstimateRequests = keywordEstimateRequests.ToArray();
            adGroupEstimateRequest.maxCpc = new Money();
            adGroupEstimateRequest.maxCpc.microAmount = 1000000;

            // Create campaign estimate requests.
            CampaignEstimateRequest campaignEstimateRequest = new CampaignEstimateRequest();
            campaignEstimateRequest.adGroupEstimateRequests = new AdGroupEstimateRequest[] {
          adGroupEstimateRequest};

            // See http://code.google.com/apis/adwords/docs/appendix/countrycodes.html
            // for a detailed list of country codes.
            Location countryCriterion = new Location();
            countryCriterion.id = 2840; //US

            // See http://code.google.com/apis/adwords/docs/appendix/languagecodes.html
            // for a detailed list of language codes.
            Language languageCriterion = new Language();
            languageCriterion.id = 1000; //en

            campaignEstimateRequest.criteria = new Criterion[] { countryCriterion, languageCriterion };

            // Create the selector.
            TrafficEstimatorSelector selector = new TrafficEstimatorSelector();
            selector.campaignEstimateRequests = new CampaignEstimateRequest[] { campaignEstimateRequest };

            try
            {
                // Get traffic estimates.
                TrafficEstimatorResult result = trafficEstimatorService.get(selector);

                // Display traffic estimates.
                if (result != null && result.campaignEstimates != null &&
                    result.campaignEstimates.Length > 0)
                {
                    CampaignEstimate campaignEstimate = result.campaignEstimates[0];
                    if (campaignEstimate.adGroupEstimates != null &&
                        campaignEstimate.adGroupEstimates.Length > 0)
                    {
                        AdGroupEstimate adGroupEstimate = campaignEstimate.adGroupEstimates[0];

                        if (adGroupEstimate.keywordEstimates != null)
                        {
                            for (int i = 0; i < adGroupEstimate.keywordEstimates.Length; i++)
                            {
                                Keyword keyword = keywordEstimateRequests[i].keyword;
                                KeywordEstimate keywordEstimate = adGroupEstimate.keywordEstimates[i];

                                if (keywordEstimateRequests[i].isNegative)
                                {
                                    continue;
                                }

                                // Find the mean of the min and max values.
                                long meanAverageCpc = (keywordEstimate.min.averageCpc.microAmount
                                    + keywordEstimate.max.averageCpc.microAmount) / 2;
                                double meanAveragePosition = (keywordEstimate.min.averagePosition
                                    + keywordEstimate.max.averagePosition) / 2;
                                float meanClicks = (keywordEstimate.min.clicksPerDay
                                   + keywordEstimate.max.clicksPerDay) / 2;
                                long meanTotalCost = (keywordEstimate.min.totalCost.microAmount
                                   + keywordEstimate.max.totalCost.microAmount) / 2;

                                Console.WriteLine("Results for the keyword with text = '{0}' and match type = " +
                                     "'{1}':", keyword.text, keyword.matchType);
                                Console.WriteLine("  Estimated average CPC: {0}", meanAverageCpc);
                                Console.WriteLine("  Estimated ad position: {0:0.00}", meanAveragePosition);
                                Console.WriteLine("  Estimated daily clicks: {0}", meanClicks);
                                Console.WriteLine("  Estimated daily cost: {0}", meanTotalCost);
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No traffic estimates were returned.\n");
                }
            }
            catch (Exception ex)
            {
                throw new System.ApplicationException("Failed to retrieve traffic estimates.", ex);
            }
        }
    }
}
