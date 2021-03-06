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
    using Amazon.ElasticTranscoder.Model;
    using Amazon.Runtime.Internal.Transform;

    namespace Amazon.ElasticTranscoder.Model.Internal.MarshallTransformations
    {
      /// <summary>
      /// JobWatermarkUnmarshaller
      /// </summary>
      internal class JobWatermarkUnmarshaller : IUnmarshaller<JobWatermark, XmlUnmarshallerContext>, IUnmarshaller<JobWatermark, JsonUnmarshallerContext>
      {
        JobWatermark IUnmarshaller<JobWatermark, XmlUnmarshallerContext>.Unmarshall(XmlUnmarshallerContext context)
        {
          throw new NotImplementedException();
        }

        public JobWatermark Unmarshall(JsonUnmarshallerContext context)
        {
            context.Read();
            if (context.CurrentTokenType == JsonToken.Null) return null;
            JobWatermark jobWatermark = new JobWatermark();
        
        
            int targetDepth = context.CurrentDepth;
            while (context.ReadAtDepth(targetDepth))
            {
              
              if (context.TestExpression("PresetWatermarkId", targetDepth))
              {
                jobWatermark.PresetWatermarkId = StringUnmarshaller.GetInstance().Unmarshall(context);
                continue;
              }
  
              if (context.TestExpression("InputKey", targetDepth))
              {
                jobWatermark.InputKey = StringUnmarshaller.GetInstance().Unmarshall(context);
                continue;
              }
  
            }
          
            return jobWatermark;
        }

        private static JobWatermarkUnmarshaller instance;
        public static JobWatermarkUnmarshaller GetInstance()
        {
            if (instance == null)
                instance = new JobWatermarkUnmarshaller();
            return instance;
        }
    }
}
  
