import React from 'react';

export default class Article extends React.Component{
   
    render(){
        const {title} = this.props;
        
        return (
          <div className="col-md-4">
              <h2>{title}</h2>
              <p>Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır.</p>
              <a className="btn btn-default" href="#">More info</a>
          </div>
        );
    }
}
