/*
 * Copyright 2010-2014 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License").
 * You may not use this file except in compliance with the License.
 * A copy of the License is located at
 * 
 *  http://aws.amazon.com/apache2.0
 * 
 * or in the "license" file accompanying this file. This file is distributed
 * on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
 * express or implied. See the License for the specific language governing
 * permissions and limitations under the License.
 */
    using System;
    using System.Collections.Generic;
    using System.IO;
    using ThirdParty.Json.LitJson;
    using Amazon.ElasticMapReduce.Model;
    using Amazon.Runtime.Internal.Transform;

    namespace Amazon.ElasticMapReduce.Model.Internal.MarshallTransformations
    {
      /// <summary>
      /// HadoopStepConfigUnmarshaller
      /// </summary>
      internal class HadoopStepConfigUnmarshaller : IUnmarshaller<HadoopStepConfig, XmlUnmarshallerContext>, IUnmarshaller<HadoopStepConfig, JsonUnmarshallerContext>
      {
        HadoopStepConfig IUnmarshaller<HadoopStepConfig, XmlUnmarshallerContext>.Unmarshall(XmlUnmarshallerContext context)
        {
          throw new NotImplementedException();
        }

        public HadoopStepConfig Unmarshall(JsonUnmarshallerContext context)
        {
            context.Read();
            if (context.CurrentTokenType == JsonToken.Null) return null;
            HadoopStepConfig hadoopStepConfig = new HadoopStepConfig();
        
        
            int targetDepth = context.CurrentDepth;
            while (context.ReadAtDepth(targetDepth))
            {
              
              if (context.TestExpression("Jar", targetDepth))
              {
                hadoopStepConfig.Jar = StringUnmarshaller.GetInstance().Unmarshall(context);
                continue;
              }
  
              if (context.TestExpression("Properties", targetDepth))
              {
                
                var unmarshaller =  new DictionaryUnmarshaller<String,String,StringUnmarshaller,StringUnmarshaller>(
                    StringUnmarshaller.GetInstance(),StringUnmarshaller.GetInstance());               
                hadoopStepConfig.Properties = unmarshaller.Unmarshall(context);
                
                continue;
              }
  
              if (context.TestExpression("MainClass", targetDepth))
              {
                hadoopStepConfig.MainClass = StringUnmarshaller.GetInstance().Unmarshall(context);
                continue;
              }
  
              if (context.TestExpression("Args", targetDepth))
              {
                
                var unmarshaller = new ListUnmarshaller<String,StringUnmarshaller>(
                    StringUnmarshaller.GetInstance());                  
                hadoopStepConfig.Args = unmarshaller.Unmarshall(context);
                
                continue;
              }
  
            }
          
            return hadoopStepConfig;
        }

        private static HadoopStepConfigUnmarshaller instance;
        public static HadoopStepConfigUnmarshaller GetInstance()
        {
            if (instance == null)
                instance = new HadoopStepConfigUnmarshaller();
            return instance;
        }
    }
}
  
