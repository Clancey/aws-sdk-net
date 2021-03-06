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

using System.IO;
using System.Xml;
using System.Text;
using Amazon.S3.Util;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
    /// <summary>
    /// Enable Bucket Logging Request Marshaller
    /// </summary>       
    public class PutBucketLoggingRequestMarshaller : IMarshaller<IRequest, PutBucketLoggingRequest>
    {
        public IRequest Marshall(PutBucketLoggingRequest putBucketLoggingRequest)
        {
            IRequest request = new DefaultRequest(putBucketLoggingRequest, "AmazonS3");

            request.HttpMethod = "PUT";

            var uriResourcePath = string.Concat("/", S3Transforms.ToStringValue(putBucketLoggingRequest.BucketName));

            request.Parameters.Add("logging", null);

            request.CanonicalResource = S3Transforms.GetCanonicalResource(uriResourcePath, request.Parameters);
            request.ResourcePath = S3Transforms.FormatResourcePath(uriResourcePath, request.Parameters);

            var stringWriter = new StringWriter(System.Globalization.CultureInfo.InvariantCulture);

            using (var xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings() { Encoding = System.Text.Encoding.UTF8, OmitXmlDeclaration = true }))
            {
                xmlWriter.WriteStartElement("BucketLoggingStatus", "");
                var bucketLoggingStatusBucketLoggingStatus = putBucketLoggingRequest.LoggingConfig;
                if (bucketLoggingStatusBucketLoggingStatus != null)
                {
                    if (bucketLoggingStatusBucketLoggingStatus != null)
                    {
                        var loggingEnabledLoggingEnabled = bucketLoggingStatusBucketLoggingStatus;
                        if (loggingEnabledLoggingEnabled != null && loggingEnabledLoggingEnabled.IsSetTargetBucket())
                        {
                            xmlWriter.WriteStartElement("LoggingEnabled", "");
                            xmlWriter.WriteElementString("TargetBucket", "", S3Transforms.ToXmlStringValue(loggingEnabledLoggingEnabled.TargetBucketName));

                            var loggingEnabledLoggingEnabledtargetGrantsList = loggingEnabledLoggingEnabled.Grants;
                            if (loggingEnabledLoggingEnabledtargetGrantsList != null && loggingEnabledLoggingEnabledtargetGrantsList.Count > 0)
                            {
                                xmlWriter.WriteStartElement("TargetGrants", "");
                                foreach (var loggingEnabledLoggingEnabledtargetGrantsListValue in loggingEnabledLoggingEnabledtargetGrantsList)
                                {
                                    xmlWriter.WriteStartElement("Grant", "");
                                    if (loggingEnabledLoggingEnabledtargetGrantsListValue != null)
                                    {
                                        var granteeGrantee = loggingEnabledLoggingEnabledtargetGrantsListValue.Grantee;
                                        if (granteeGrantee != null)
                                        {
                                            xmlWriter.WriteStartElement("Grantee", "");
                                            if (granteeGrantee.IsSetType())
                                            {
                                                xmlWriter.WriteAttributeString("xsi", "type", "http://www.w3.org/2001/XMLSchema-instance", granteeGrantee.Type.ToString());
                                            }
                                            if (granteeGrantee.IsSetDisplayName())
                                            {
                                                xmlWriter.WriteElementString("DisplayName", "", S3Transforms.ToXmlStringValue(granteeGrantee.DisplayName));
                                            }
                                            if (granteeGrantee.IsSetEmailAddress())
                                            {
                                                xmlWriter.WriteElementString("EmailAddress", "", S3Transforms.ToXmlStringValue(granteeGrantee.EmailAddress));
                                            }
                                            if (granteeGrantee.IsSetCanonicalUser())
                                            {
                                                xmlWriter.WriteElementString("ID", "", S3Transforms.ToXmlStringValue(granteeGrantee.CanonicalUser));
                                            }
                                            if (granteeGrantee.IsSetURI())
                                            {
                                                xmlWriter.WriteElementString("URI", "", S3Transforms.ToXmlStringValue(granteeGrantee.URI));
                                            }
                                            xmlWriter.WriteEndElement();
                                        }

                                        if (loggingEnabledLoggingEnabledtargetGrantsListValue.IsSetPermission())
                                        {
                                            xmlWriter.WriteElementString("Permission", "", S3Transforms.ToXmlStringValue(loggingEnabledLoggingEnabledtargetGrantsListValue.Permission));
                                        }
                                    }

                                    xmlWriter.WriteEndElement();
                                }
                                xmlWriter.WriteEndElement();
                            }
                            if (loggingEnabledLoggingEnabled.IsSetTargetPrefix())
                            {
                                xmlWriter.WriteElementString("TargetPrefix", "", S3Transforms.ToXmlStringValue(loggingEnabledLoggingEnabled.TargetPrefix));
                            }
                            else
                            {
                                xmlWriter.WriteStartElement("TargetPrefix");
                                xmlWriter.WriteEndElement();
                            }
                            xmlWriter.WriteEndElement();
                        }
                    }
                }

                xmlWriter.WriteEndElement();
            }

            try
            {
                var content = stringWriter.ToString();
                request.Content = Encoding.UTF8.GetBytes(content);
                request.Headers["Content-Type"] = "application/xml";

                request.Parameters[S3QueryParameter.ContentType.ToString()] = "application/xml";
                var checksum = AmazonS3Util.GenerateChecksumForContent(content, true);
                request.Headers[Amazon.Util.AWSSDKUtils.ContentMD5Header] = checksum;
            }
            catch (EncoderFallbackException e)
            {
                throw new AmazonServiceException("Unable to marshall request to XML", e);
            }

            if (!request.UseQueryString)
            {
                var queryString = Amazon.Util.AWSSDKUtils.GetParametersAsString(request.Parameters);
                if (!string.IsNullOrEmpty(queryString))
                {
                    request.ResourcePath = string.Concat(request.ResourcePath, request.ResourcePath.Contains("?") ? "&" : "?", queryString);
                }
            }

            return request;
        }
    }
}

