import React, { Component } from 'react';
import tinymce from 'tinymce';
import 'tinymce/themes/modern';
import 'tinymce/plugins/wordcount';
import 'tinymce/plugins/table';

class TinyEditorComponent extends Component {
  constructor() {
    super();
    this.state = { editor: null };
  }
  componentDidMount() {
    console.log(process.env.PUBLIC_URL)
    tinymce.init({
      selector: `#${this.props.id}`,
      theme: 'modern',
      skin_url: "http://localhost:18077/static/skins/lightgray/",
      plugins: 'wordcount table',
      setup: editor => {
        this.setState({ editor });
        editor.on('keyup change', () => {
          const content = editor.getContent();
          this.props.onEditorChange(content);
        });
      }
    });
  }

  componentWillUnmount() {
    tinymce.remove(this.state.editor);
  }

  render() {
    return (
      <textarea
        id={this.props.id}
        value={this.props.content}
        onChange={e => console.log(e)}
      />
    );
  }
}

export default TinyEditorComponent;