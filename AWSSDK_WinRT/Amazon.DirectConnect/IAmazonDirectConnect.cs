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
using System.Threading;
using System.Threading.Tasks;

using Amazon.DirectConnect.Model;

namespace Amazon.DirectConnect
{
    /// <summary>
    /// Interface for accessing AmazonDirectConnect.
    /// 
    /// <para>AWS Direct Connect makes it easy to establish a dedicated network connection from your premises to Amazon Web Services (AWS). Using
    /// AWS Direct Connect, you can establish private connectivity between AWS and your data center, office, or colocation environment, which in
    /// many cases can reduce your network costs, increase bandwidth throughput, and provide a more consistent network experience than
    /// Internet-based connections.</para> <para>The AWS Direct Connect API Reference provides descriptions, syntax, and usage examples for each of
    /// the actions and data types for AWS Direct Connect. Use the following links to get started using the <i>AWS Direct Connect API Reference</i>
    /// :</para>
    /// <ul>
    /// <li> <a href="http://docs.aws.amazon.com/directconnect/latest/APIReference/API_Operations.html">Actions</a> : An alphabetical list of all
    /// AWS Direct Connect actions.</li>
    /// <li> <a href="http://docs.aws.amazon.com/directconnect/latest/APIReference/API_Types.html">Data Types</a> : An alphabetical list of all
    /// AWS Direct Connect data types.</li>
    /// <li> <a href="http://docs.aws.amazon.com/directconnect/latest/APIReference/CommonParameters.html">Common Query Parameters</a> : Parameters
    /// that all Query actions can use.</li>
    /// <li> <a href="http://docs.aws.amazon.com/directconnect/latest/APIReference/CommonErrors.html">Common Errors</a> : Client and server errors
    /// that all actions can return.</li>
    /// 
    /// </ul>
    /// </summary>
	public partial interface IAmazonDirectConnect : IDisposable
    {
 
        /// <summary>
        /// <para>Creates a hosted connection on an interconnect.</para> <para>Allocates a VLAN number and a specified amount of bandwidth for use by a
        /// hosted connection on the given interconnect.</para>
        /// </summary>
        /// 
        /// <param name="allocateConnectionOnInterconnectRequest">Container for the necessary parameters to execute the AllocateConnectionOnInterconnect
        /// service method on AmazonDirectConnect.</param>
        /// 
        /// <returns>The response from the AllocateConnectionOnInterconnect service method, as returned by AmazonDirectConnect.</returns>
        /// 
        /// <exception cref="T:Amazon.DirectConnect.Model.DirectConnectServerException" />
        /// <exception cref="T:Amazon.DirectConnect.Model.DirectConnectClientException" />
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
		Task<AllocateConnectionOnInterconnectResponse> AllocateConnectionOnInterconnectAsync(AllocateConnectionOnInterconnectRequest allocateConnectionOnInterconnectRequest, CancellationToken cancellationToken = default(CancellationToken));
 
        /// <summary>
        /// <para>Provisions a private virtual interface to be owned by a different customer.</para> <para>The owner of a connection calls this function
        /// to provision a private virtual interface which will be owned by another AWS customer.</para> <para>Virtual interfaces created using this
        /// function must be confirmed by the virtual interface owner by calling ConfirmPrivateVirtualInterface. Until this step has been completed,
        /// the virtual interface will be in 'Confirming' state, and will not be available for handling traffic.</para>
        /// </summary>
        /// 
        /// <param name="allocatePrivateVirtualInterfaceRequest">Container for the necessary parameters to execute the AllocatePrivateVirtualInterface
        /// service method on AmazonDirectConnect.</param>
        /// 
        /// <returns>The response from the AllocatePrivateVirtualInterface service method, as returned by AmazonDirectConnect.</returns>
        /// 
        /// <exception cref="T:Amazon.DirectConnect.Model.DirectConnectServerException" />
        /// <exception cref="T:Amazon.DirectConnect.Model.DirectConnectClientException" />
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
		Task<AllocatePrivateVirtualInterfaceResponse> AllocatePrivateVirtualInterfaceAsync(AllocatePrivateVirtualInterfaceRequest allocatePrivateVirtualInterfaceRequest, CancellationToken cancellationToken = default(CancellationToken));
 
        /// <summary>
        /// <para>Provisions a public virtual interface to be owned by a different customer.</para> <para>The owner of a connection calls this function
        /// to provision a public virtual interface which will be owned by another AWS customer.</para> <para>Virtual interfaces created using this
        /// function must be confirmed by the virtual interface owner by calling ConfirmPublicVirtualInterface. Until this step has been completed, the
        /// virtual interface will be in 'Confirming' state, and will not be available for handling traffic.</para>
        /// </summary>
        /// 
        /// <param name="allocatePublicVirtualInterfaceRequest">Container for the necessary parameters to execute the AllocatePublicVirtualInterface
        /// service method on AmazonDirectConnect.</param>
        /// 
        /// <returns>The response from the AllocatePublicVirtualInterface service method, as returned by AmazonDirectConnect.</returns>
        /// 
        /// <exception cref="T:Amazon.DirectConnect.Model.DirectConnectServerException" />
        /// <exception cref="T:Amazon.DirectConnect.Model.DirectConnectClientException" />
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
		Task<AllocatePublicVirtualInterfaceResponse> AllocatePublicVirtualInterfaceAsync(AllocatePublicVirtualInterfaceRequest allocatePublicVirtualInterfaceRequest, CancellationToken cancellationToken = default(CancellationToken));
 
        /// <summary>
        /// <para>Confirm the creation of a hosted connection on an interconnect.</para> <para>Upon creation, the hosted connection is initially in the
        /// 'Ordering' state, and will remain in this state until the owner calls ConfirmConnection to confirm creation of the hosted connection.</para>
        /// </summary>
        /// 
        /// <param name="confirmConnectionRequest">Container for the necessary parameters to execute the ConfirmConnection service method on
        /// AmazonDirectConnect.</param>
        /// 
        /// <returns>The response from the ConfirmConnection service method, as returned by AmazonDirectConnect.</returns>
        /// 
        /// <exception cref="T:Amazon.DirectConnect.Model.DirectConnectServerException" />
        /// <exception cref="T:Amazon.DirectConnect.Model.DirectConnectClientException" />
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
		Task<ConfirmConnectionResponse> ConfirmConnectionAsync(ConfirmConnectionRequest confirmConnectionRequest, CancellationToken cancellationToken = default(CancellationToken));
 
        /// <summary>
        /// <para>Accept ownership of a private virtual interface created by another customer.</para> <para>After the virtual interface owner calls this
        /// function, the virtual interface will be created and attached to the given virtual private gateway, and will be available for handling
        /// traffic.</para>
        /// </summary>
        /// 
        /// <param name="confirmPrivateVirtualInterfaceRequest">Container for the necessary parameters to execute the ConfirmPrivateVirtualInterface
        /// service method on AmazonDirectConnect.</param>
        /// 
        /// <returns>The response from the ConfirmPrivateVirtualInterface service method, as returned by AmazonDirectConnect.</returns>
        /// 
        /// <exception cref="T:Amazon.DirectConnect.Model.DirectConnectServerException" />
        /// <exception cref="T:Amazon.DirectConnect.Model.DirectConnectClientException" />
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
		Task<ConfirmPrivateVirtualInterfaceResponse> ConfirmPrivateVirtualInterfaceAsync(ConfirmPrivateVirtualInterfaceRequest confirmPrivateVirtualInterfaceRequest, CancellationToken cancellationToken = default(CancellationToken));
 
        /// <summary>
        /// <para>Accept ownership of a public virtual interface created by another customer.</para> <para>After the virtual interface owner calls this
        /// function, the specified virtual interface will be created and made available for handling traffic.</para>
        /// </summary>
        /// 
        /// <param name="confirmPublicVirtualInterfaceRequest">Container for the necessary parameters to execute the ConfirmPublicVirtualInterface
        /// service method on AmazonDirectConnect.</param>
        /// 
        /// <returns>The response from the ConfirmPublicVirtualInterface service method, as returned by AmazonDirectConnect.</returns>
        /// 
        /// <exception cref="T:Amazon.DirectConnect.Model.DirectConnectServerException" />
        /// <exception cref="T:Amazon.DirectConnect.Model.DirectConnectClientException" />
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
		Task<ConfirmPublicVirtualInterfaceResponse> ConfirmPublicVirtualInterfaceAsync(ConfirmPublicVirtualInterfaceRequest confirmPublicVirtualInterfaceRequest, CancellationToken cancellationToken = default(CancellationToken));
 
        /// <summary>
        /// <para>Creates a new connection between the customer network and a specific AWS Direct Connect location.</para> <para>A connection links your
        /// internal network to an AWS Direct Connect location over a standard 1 gigabit or 10 gigabit Ethernet fiber-optic cable. One end of the cable
        /// is connected to your router, the other to an AWS Direct Connect router. A Direct Connect location provides access to Amazon Web Services in
        /// the region it is associated with. You can establish connections with AWS Direct Connect locations in multiple regions, but a connection in
        /// one region does not provide connectivity to other regions.</para>
        /// </summary>
        /// 
        /// <param name="createConnectionRequest">Container for the necessary parameters to execute the CreateConnection service method on
        /// AmazonDirectConnect.</param>
        /// 
        /// <returns>The response from the CreateConnection service method, as returned by AmazonDirectConnect.</returns>
        /// 
        /// <exception cref="T:Amazon.DirectConnect.Model.DirectConnectServerException" />
        /// <exception cref="T:Amazon.DirectConnect.Model.DirectConnectClientException" />
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
		Task<CreateConnectionResponse> CreateConnectionAsync(CreateConnectionRequest createConnectionRequest, CancellationToken cancellationToken = default(CancellationToken));
 
        /// <summary>
        /// <para>Creates a new interconnect between a Direct Connect partner's network and a specific AWS Direct Connect location.</para> <para>An
        /// interconnect is a connection which is capable of hosting other connections. The AWS Direct Connect partner can use an interconnect to
        /// provide sub-1Gbps Direct Connect service to tier 2 customers who do not have their own connections. Like a standard connection, an
        /// interconnect links the Direct Connect partner's network to an AWS Direct Connect location over a standard 1 Gbps or 10 Gbps Ethernet
        /// fiber-optic cable. One end is connected to the partner's router, the other to an AWS Direct Connect router.</para> <para>For each end
        /// customer, the Direct Connect partner provisions a connection on their interconnect by calling AllocateConnectionOnInterconnect. The end
        /// customer can then connect to AWS resources by creating a virtual interface on their connection, using the VLAN assigned to them by the
        /// Direct Connect partner.</para>
        /// </summary>
        /// 
        /// <param name="createInterconnectRequest">Container for the necessary parameters to execute the CreateInterconnect service method on
        /// AmazonDirectConnect.</param>
        /// 
        /// <returns>The response from the CreateInterconnect service method, as returned by AmazonDirectConnect.</returns>
        /// 
        /// <exception cref="T:Amazon.DirectConnect.Model.DirectConnectServerException" />
        /// <exception cref="T:Amazon.DirectConnect.Model.DirectConnectClientException" />
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
		Task<CreateInterconnectResponse> CreateInterconnectAsync(CreateInterconnectRequest createInterconnectRequest, CancellationToken cancellationToken = default(CancellationToken));
 
        /// <summary>
        /// <para>Creates a new private virtual interface. A virtual interface is the VLAN that transports AWS Direct Connect traffic. A private
        /// virtual interface supports sending traffic to a single Virtual Private Cloud (VPC).</para>
        /// </summary>
        /// 
        /// <param name="createPrivateVirtualInterfaceRequest">Container for the necessary parameters to execute the CreatePrivateVirtualInterface
        /// service method on AmazonDirectConnect.</param>
        /// 
        /// <returns>The response from the CreatePrivateVirtualInterface service method, as returned by AmazonDirectConnect.</returns>
        /// 
        /// <exception cref="T:Amazon.DirectConnect.Model.DirectConnectServerException" />
        /// <exception cref="T:Amazon.DirectConnect.Model.DirectConnectClientException" />
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
		Task<CreatePrivateVirtualInterfaceResponse> CreatePrivateVirtualInterfaceAsync(CreatePrivateVirtualInterfaceRequest createPrivateVirtualInterfaceRequest, CancellationToken cancellationToken = default(CancellationToken));
 
        /// <summary>
        /// <para>Creates a new public virtual interface. A virtual interface is the VLAN that transports AWS Direct Connect traffic. A public virtual
        /// interface supports sending traffic to public services of AWS such as Amazon Simple Storage Service (Amazon S3).</para>
        /// </summary>
        /// 
        /// <param name="createPublicVirtualInterfaceRequest">Container for the necessary parameters to execute the CreatePublicVirtualInterface service
        /// method on AmazonDirectConnect.</param>
        /// 
        /// <returns>The response from the CreatePublicVirtualInterface service method, as returned by AmazonDirectConnect.</returns>
        /// 
        /// <exception cref="T:Amazon.DirectConnect.Model.DirectConnectServerException" />
        /// <exception cref="T:Amazon.DirectConnect.Model.DirectConnectClientException" />
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
		Task<CreatePublicVirtualInterfaceResponse> CreatePublicVirtualInterfaceAsync(CreatePublicVirtualInterfaceRequest createPublicVirtualInterfaceRequest, CancellationToken cancellationToken = default(CancellationToken));
 
        /// <summary>
        /// <para>Deletes the connection.</para> <para>Deleting a connection only stops the AWS Direct Connect port hour and data transfer charges. You
        /// separately need to cancel any services or charges for cross-connects or network circuits that connect you to the AWS Direct Connect location
        /// with the providers of those services.</para>
        /// </summary>
        /// 
        /// <param name="deleteConnectionRequest">Container for the necessary parameters to execute the DeleteConnection service method on
        /// AmazonDirectConnect.</param>
        /// 
        /// <returns>The response from the DeleteConnection service method, as returned by AmazonDirectConnect.</returns>
        /// 
        /// <exception cref="T:Amazon.DirectConnect.Model.DirectConnectServerException" />
        /// <exception cref="T:Amazon.DirectConnect.Model.DirectConnectClientException" />
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
		Task<DeleteConnectionResponse> DeleteConnectionAsync(DeleteConnectionRequest deleteConnectionRequest, CancellationToken cancellationToken = default(CancellationToken));
 
        /// <summary>
        /// <para>Deletes the specified interconnect.</para>
        /// </summary>
        /// 
        /// <param name="deleteInterconnectRequest">Container for the necessary parameters to execute the DeleteInterconnect service method on
        /// AmazonDirectConnect.</param>
        /// 
        /// <returns>The response from the DeleteInterconnect service method, as returned by AmazonDirectConnect.</returns>
        /// 
        /// <exception cref="T:Amazon.DirectConnect.Model.DirectConnectServerException" />
        /// <exception cref="T:Amazon.DirectConnect.Model.DirectConnectClientException" />
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
		Task<DeleteInterconnectResponse> DeleteInterconnectAsync(DeleteInterconnectRequest deleteInterconnectRequest, CancellationToken cancellationToken = default(CancellationToken));
 
        /// <summary>
        /// <para>Deletes a virtual interface.</para>
        /// </summary>
        /// 
        /// <param name="deleteVirtualInterfaceRequest">Container for the necessary parameters to execute the DeleteVirtualInterface service method on
        /// AmazonDirectConnect.</param>
        /// 
        /// <returns>The response from the DeleteVirtualInterface service method, as returned by AmazonDirectConnect.</returns>
        /// 
        /// <exception cref="T:Amazon.DirectConnect.Model.DirectConnectServerException" />
        /// <exception cref="T:Amazon.DirectConnect.Model.DirectConnectClientException" />
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
		Task<DeleteVirtualInterfaceResponse> DeleteVirtualInterfaceAsync(DeleteVirtualInterfaceRequest deleteVirtualInterfaceRequest, CancellationToken cancellationToken = default(CancellationToken));
 
        /// <summary>
        /// <para>Displays all connections in this region.</para> <para>If a connection ID is provided, it will only return this particular
        /// connection.</para>
        /// </summary>
        /// 
        /// <param name="describeConnectionsRequest">Container for the necessary parameters to execute the DescribeConnections service method on
        /// AmazonDirectConnect.</param>
        /// 
        /// <returns>The response from the DescribeConnections service method, as returned by AmazonDirectConnect.</returns>
        /// 
        /// <exception cref="T:Amazon.DirectConnect.Model.DirectConnectServerException" />
        /// <exception cref="T:Amazon.DirectConnect.Model.DirectConnectClientException" />
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
		Task<DescribeConnectionsResponse> DescribeConnectionsAsync(DescribeConnectionsRequest describeConnectionsRequest, CancellationToken cancellationToken = default(CancellationToken));
 
        /// <summary>
        /// <para>Return a list of connections that have been provisioned on the given interconnect.</para>
        /// </summary>
        /// 
        /// <param name="describeConnectionsOnInterconnectRequest">Container for the necessary parameters to execute the
        /// DescribeConnectionsOnInterconnect service method on AmazonDirectConnect.</param>
        /// 
        /// <returns>The response from the DescribeConnectionsOnInterconnect service method, as returned by AmazonDirectConnect.</returns>
        /// 
        /// <exception cref="T:Amazon.DirectConnect.Model.DirectConnectServerException" />
        /// <exception cref="T:Amazon.DirectConnect.Model.DirectConnectClientException" />
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
		Task<DescribeConnectionsOnInterconnectResponse> DescribeConnectionsOnInterconnectAsync(DescribeConnectionsOnInterconnectRequest describeConnectionsOnInterconnectRequest, CancellationToken cancellationToken = default(CancellationToken));
 
        /// <summary>
        /// <para>Returns a list of interconnects owned by the AWS account.</para> <para>If an interconnect ID is provided, it will only return this
        /// particular interconnect.</para>
        /// </summary>
        /// 
        /// <param name="describeInterconnectsRequest">Container for the necessary parameters to execute the DescribeInterconnects service method on
        /// AmazonDirectConnect.</param>
        /// 
        /// <returns>The response from the DescribeInterconnects service method, as returned by AmazonDirectConnect.</returns>
        /// 
        /// <exception cref="T:Amazon.DirectConnect.Model.DirectConnectServerException" />
        /// <exception cref="T:Amazon.DirectConnect.Model.DirectConnectClientException" />
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
		Task<DescribeInterconnectsResponse> DescribeInterconnectsAsync(DescribeInterconnectsRequest describeInterconnectsRequest, CancellationToken cancellationToken = default(CancellationToken));
 
        /// <summary>
        /// <para>Returns the list of Direct Connect locations in the current AWS region. These are the locations that may be selected when calling
        /// CreateConnection or CreateInterconnect.</para>
        /// </summary>
        /// 
        /// <param name="describeLocationsRequest">Container for the necessary parameters to execute the DescribeLocations service method on
        /// AmazonDirectConnect.</param>
        /// 
        /// <returns>The response from the DescribeLocations service method, as returned by AmazonDirectConnect.</returns>
        /// 
        /// <exception cref="T:Amazon.DirectConnect.Model.DirectConnectServerException" />
        /// <exception cref="T:Amazon.DirectConnect.Model.DirectConnectClientException" />
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
		Task<DescribeLocationsResponse> DescribeLocationsAsync(DescribeLocationsRequest describeLocationsRequest, CancellationToken cancellationToken = default(CancellationToken));
 
        /// <summary>
        /// <para>Returns a list of virtual private gateways owned by the AWS account.</para> <para>You can create one or more AWS Direct Connect
        /// private virtual interfaces linking to a virtual private gateway. A virtual private gateway can be managed via Amazon Virtual Private Cloud
        /// (VPC) console or the <a href="http://docs.aws.amazon.com/AWSEC2/latest/APIReference/ApiReference-query-CreateVpnGateway.html">EC2
        /// CreateVpnGateway</a> action.</para>
        /// </summary>
        /// 
        /// <param name="describeVirtualGatewaysRequest">Container for the necessary parameters to execute the DescribeVirtualGateways service method on
        /// AmazonDirectConnect.</param>
        /// 
        /// <returns>The response from the DescribeVirtualGateways service method, as returned by AmazonDirectConnect.</returns>
        /// 
        /// <exception cref="T:Amazon.DirectConnect.Model.DirectConnectServerException" />
        /// <exception cref="T:Amazon.DirectConnect.Model.DirectConnectClientException" />
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
		Task<DescribeVirtualGatewaysResponse> DescribeVirtualGatewaysAsync(DescribeVirtualGatewaysRequest describeVirtualGatewaysRequest, CancellationToken cancellationToken = default(CancellationToken));
 
        /// <summary>
        /// <para>Displays all virtual interfaces for an AWS account. Virtual interfaces deleted fewer than 15 minutes before DescribeVirtualInterfaces
        /// is called are also returned. If a connection ID is included then only virtual interfaces associated with this connection will be returned.
        /// If a virtual interface ID is included then only a single virtual interface will be returned.</para> <para> A virtual interface (VLAN)
        /// transmits the traffic between the Direct Connect location and the customer.</para> <para>If a connection ID is provided, only virtual
        /// interfaces provisioned on the specified connection will be returned. If a virtual interface ID is provided, only this particular virtual
        /// interface will be returned.</para>
        /// </summary>
        /// 
        /// <param name="describeVirtualInterfacesRequest">Container for the necessary parameters to execute the DescribeVirtualInterfaces service
        /// method on AmazonDirectConnect.</param>
        /// 
        /// <returns>The response from the DescribeVirtualInterfaces service method, as returned by AmazonDirectConnect.</returns>
        /// 
        /// <exception cref="T:Amazon.DirectConnect.Model.DirectConnectServerException" />
        /// <exception cref="T:Amazon.DirectConnect.Model.DirectConnectClientException" />
        /// <param name="cancellationToken">
        ///     A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
		Task<DescribeVirtualInterfacesResponse> DescribeVirtualInterfacesAsync(DescribeVirtualInterfacesRequest describeVirtualInterfacesRequest, CancellationToken cancellationToken = default(CancellationToken));
    }
}
