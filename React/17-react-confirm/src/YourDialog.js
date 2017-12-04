import React from 'react';
import PropTypes from 'prop-types';
import { confirmable } from 'react-confirm';

const YourDialog = ({ show, proceed, dismiss, cancel, confirmation, options }) => {
  return (
    <div onHide={dismiss} show={show}>
      {confirmation}
      <button onClick={() => cancel('arguments will be passed to the callback')}>CANCEL</button>
      <button onClick={() => proceed('same as cancel')}>OK</button>
    </div>
  )
}

YourDialog.propTypes = {
  show: PropTypes.bool,            // from confirmable. indicates if the dialog is shown or not.
  proceed: PropTypes.func,         // from confirmable. call to close the dialog with promise resolved.
  cancel: PropTypes.func,          // from confirmable. call to close the dialog with promise rejected.
  dismiss: PropTypes.func,         // from confirmable. call to only close the dialog.
  confirmation: PropTypes.string,  // arguments of your confirm function
  options: PropTypes.object        // arguments of your confirm function
}

// confirmable HOC pass props `show`, `dismiss`, `cancel` and `proceed` to your component.
export default confirmable(YourDialog);