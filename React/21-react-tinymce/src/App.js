import React from 'react';
import { Editor } from '@tinymce/tinymce-react';

class App extends React.Component {
  constructor() {
    super();
    this.state = {
      content: null
    }
  }
  
  render() {
    return (
      <Editor
        initialValue="<p>This is the initial content of the editor</p>"
        init={{
          plugins: 'link image code',
          toolbar: 'undo redo | bold italic | alignleft aligncenter alignright | code'
        }}
        value={this.state.content} onEditorChange={(e) => this.setState({ content: e })}
      />
    );
  }
}

export default App;