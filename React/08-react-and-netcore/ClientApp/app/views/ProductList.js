import React, { Component } from 'react';
import axios from 'axios'

class ProductListView extends Component {
    constructor() {
        super();
        this.state = {
            products: [
                {
                    "id": 1,
                    "office": "Edinburgh",
                    "age": 61,
                    "startDate": "2014-01-05T00:00:00",
                    "salary": 0
                }
            ]
        }
    }
    refreshProductList() {
        axios.get('/api/product/list')
            .then((response) => {
                console.log(response);
                this.setState({ products: response.data });
            })
    }
    render() {
        var { products } = this.state;

        var productList = products.map((product, index) => {
            return <tr key={product.id}>
                <td>Product {product.id}</td>
                <td>{index}</td>
                <td>{product.office}</td>
                <td>{product.age}</td>
                <td>{product.startDate}</td>
                <td>$ {product.salary}</td>
            </tr>
        })

        return (
            <div className="wrapper wrapper-content animated fadeInRight">

                <div class="small-header transition animated fadeIn">
                    <div class="hpanel">
                        <div class="panel-body" style={{ backgroundColor: "#F7F9FA !important" }}>
                            <div id="hbreadcrumb" class="pull-right">
                                <ol class="hbreadcrumb breadcrumb">
                                    <li><a href="/">Home</a></li>
                                    <li><a href="#">System</a></li>
                                    <li class="active">
                                        <span>Localizer</span>
                                    </li>
                                </ol>
                            </div>
                            <h2 class="font-light m-b-xs">
                                Magage your products
                            </h2>
                            <small>Fulfilment-Software-Portal.Views.Products.DatabaseFulfilment-Software-Portal.Localizer.Header.Subtitle.en-US</small>
                        </div>
                    </div>
                </div>
                <div class="content animate-panel">
                    <div class="row">
                        <div class="col-md-3">
                            <div class="hpanel">
                                <div class="panel-body">
                                    <div class="m-b-md">
                                        <h4>
                                            Product Categories
                                        </h4>
                                        <small>
                                            Filter your products basend on diferent categories below.
                                        </small>
                                    </div>
                                    <div class="input-group" style={{ marginBottom: "10px" }}>
                                        <input id="txtSearchTree" class="form-control" type="text" placeholder="Search Products..." />
                                        <div class="input-group-btn tooltip-ffs">
                                            <button disabled="disabled" class="btn btn-default"><i class="fa fa-search"></i></button>
                                            <button id="btnAddTreeRoot" class="btn btn-default " data-toggle="tooltip" data-placement="right" title="Add new master catalog" style={{ marginLeft: "5px" }}><i class="fa fa-plus"></i></button>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div id="jsContainer">
                                            <div id="productsTree">
                                            </div>
                                        </div>
                                    </div>
                                    <button id="refreshCategories" class="btn btn-success btn-block" onClick={this.refreshProductList.bind(this)}>Refresh</button>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-9">
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="hpanel">
                                        <div class="panel-body">
                                            <div class="input-group">
                                                <input class="form-control" type="text" placeholder="Search products.." />
                                                <div class="input-group-btn">
                                                    <button class="btn btn-default"><i class="fa fa-search"></i></button>

                                                    <button id="btnRefreshProducts" class="btn btn-default" style={{ marginLeft: "10px" }}><i class="fa fa-refresh"></i>&nbsp;&nbsp; Refresh</button>

                                                    <button id="btnChooseColumns" class="btn btn-default" style={{ marginLeft: "5px" }}><i class="fa fa-columns"></i>&nbsp;&nbsp; Columns</button>

                                                    <div class="btn-group">
                                                        <button data-toggle="dropdown" class="btn btn-default dropdown-toggle"
                                                            style={{ marginLeft: "5px" }}>
                                                            <i class="fa fa-share"></i>&nbsp;&nbsp;Export&nbsp;&nbsp;<span class="caret"></span>
                                                        </button>
                                                        <ul class="dropdown-menu pull-right">
                                                            <li><a id="exportSelectionToExcel" href="#">Selection to Excel</a></li>
                                                            <li><a id="exportSelectionToCsv" href="#">Selection to CSV</a></li>
                                                            <li class="divider"></li>
                                                            <li><a id="exportAllToExcel" href="#">All to Excel</a></li>
                                                            <li><a id="exportAllToCsv" href="#">All to CSV</a></li>
                                                        </ul>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="hpanel">
                                        <div class="panel-body">
                                            <div class="table-responsive">
                                                <table id="ProductsTable" class="display table table-bordered table-select table-hover">
                                                    <thead>
                                                        <tr>
                                                            <th>Name</th>
                                                            <th>Position</th>
                                                            <th>Office</th>
                                                            <th width="15%">Age</th>
                                                            <th width="15%">Start date</th>
                                                            <th width="15%">Salary</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        {productList}
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div >
        )
    }
}

export default ProductListView