/*
 * Copyright 2010-2013 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Xml.Serialization;
using System.Text;
using System.IO;
using Amazon.Runtime;

namespace Amazon.SQS.Model
{
    /// <summary>
    /// <para> A list of returned queue attributes. </para>
    /// </summary>
    public partial class GetQueueAttributesResult : AmazonWebServiceResponse
    {
        
        private Dictionary<string,string> attributes = new Dictionary<string,string>();


        /// <summary>
        /// A map of attributes to the respective values.
        ///  
        /// </summary>
        public Dictionary<string,string> Attributes
        {
            get { return this.attributes; }
            set { this.attributes = value; }
        }

        // Check to see if Attributes property is set
        internal bool IsSetAttributes()
        {
            return this.attributes != null;
        }
    }
}
