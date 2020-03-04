import React from "react";
import PropTypes from "prop-types";

// Component
// Error
// A reusable error container
// uses bootstrap alerts
const Error = ({ err }) => {
  return (
    <div className="alert alert-danger" role="alert">
      {err}
    </div>
  );
};

Error.propTypes = {
  err: PropTypes.string.isRequired
};

export default Error;
