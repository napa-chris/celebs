using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlchemyAPI
{
    public class AlchemyAPI_NewsParams : AlchemyAPI_BaseParams
    {
        public enum SentimentType
        {
            Negative,
            Positive
        }
        public enum ScoreEquality
        {
            GreaterThan,
            LessThan
        }

        private const string TAXONOMY_LABEL = "&q.enriched.url.enrichedTitle.taxonomy.taxonomy_.label=";
        private const string CONCEPT_TEXT = "&q.enriched.url.concepts.concept.text=";
        private const string KEYWORD_TEXT = "&q.enriched.url.enrichedTitle.keywords.keyword.text=";
        private const string ENTITY_TEXT = "&q.enriched.url.enrichedTitle.entities.entity.text=";
        private const string ENTITY_TYPE = "&q.enriched.url.enrichedTitle.entities.entity.type=";
        private const string RELATION = "&q.enriched.url.enrichedTitle.relations.relation=";
        private const string SENTIMENT = "&q.enriched.url.enrichedTitle.docSentiment=";
        private const string SENTIMENT_POSITIVE = "type=positive,";
        private const string SENTIMENT_NEGATIVE = "type=negative,";

        private List<string> _taxonomy;
        private List<string> _concepts;
        private List<string> _keyWords;
        private List<string> _entityText;
        private List<string> _entityType;
        private List<string> _relations;
        private int? _sentiment;
        private SentimentType _sentimentType;
        private ScoreEquality _scoreEquality;
        private string _sentimentTypeString;
        private string _sentimentScoreEquality;
        private string _startDate;
        private string _endDate;
        private int? _count;

        public AlchemyAPI_NewsParams()
        {
            _taxonomy = new List<string>();
            _concepts = new List<string>();
            _keyWords = new List<string>();
            _entityText = new List<string>();
            _entityType = new List<string>();
            _relations = new List<string>();
        }

        public void addTaxonomy(string[] s)
        {
            foreach(var str in s)
            {
                _taxonomy.Add(str);
            }
        }
        public void addEntityText(string[] s)
        {
            foreach (var str in s)
            {
                _entityText.Add(str);
            }
        }

        public void setCount(int c)
        {
            _count = c;
        }
        public void setStartDate(int amount = 0, char dateType = 'd')
        {
            if (amount > 0)
            {
                _startDate = "&start=now-" + amount + dateType;
            }
            else
            {
                _endDate = "&start=now";
            }
        }
        public void setEndDate(int amount = 0, char dateType = 'd')
        {
            if (amount > 0)
            {
                _endDate = "&end=now-" + amount + dateType;
            }
            else
            {
                _endDate = "&end=now";            
            }
        }

        public override String getParameterString()
        {
            String retString = base.getParameterString();
            if(_count != 0 || _count != null)
            {
                retString += "&count=" + _count.ToString();
            }
            if (_taxonomy.Count > 0)
            {
                retString += TAXONOMY_LABEL + string.Join("+", _taxonomy.ToArray());
            }
            if (_concepts.Count > 0)
            {
                retString += CONCEPT_TEXT + string.Join("+", _concepts.ToArray());
            }
            if (_keyWords.Count > 0)
            {
                retString += KEYWORD_TEXT + string.Join("+", _keyWords.ToArray());
            }
            if (_entityText.Count > 0)
            {
                retString += ENTITY_TEXT + string.Join("+", _entityText.ToArray());
            }
            if (_entityType.Count > 0)
            {
                retString += ENTITY_TYPE + string.Join("+", _entityType.ToArray());
            }
            if (_relations.Count > 0)
            {
                retString += RELATION + _relations;
            }
            if (_sentiment != null)
            {
                retString += SENTIMENT + "|" + _sentimentType + "score=" + _sentimentScoreEquality + _sentiment + "|";                
            }
            retString += _startDate + _endDate;
            return retString;
        }
    }
}
