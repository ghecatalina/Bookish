import { makeStyles } from "@mui/styles";

export default makeStyles((theme) => ({
  box: {
    width: '300px',
    boxShadow: '2px 2px 30px rgba(0, 0, 0, 0.2)',
    borderRadius: '10px',
    overflow: 'hidden',
    position: 'absolute',
    left: '50%',
    top: '50%',
    transform: 'translate(-50%, -50%)',
  },
  bookImage: {
    height: '450px',
    img: {
      width: '100%',
      height: '100%',
      objectFit: 'cover',
      boxSizing: 'border-box',
    }
  },
  }));