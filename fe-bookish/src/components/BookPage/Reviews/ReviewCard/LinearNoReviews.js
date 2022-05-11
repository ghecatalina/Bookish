import LinearProgress, { linearProgressClasses } from '@mui/material/LinearProgress';
import { styled } from "@mui/styles";
import React from "react";

const LinearNoReviews = styled(LinearProgress)(({ theme }) => ({
    height: 15,
    width: 200,
    borderRadius: 5,
    [`&.${linearProgressClasses.colorPrimary}`]: {
      backgroundColor: '#DCD1C9',
    },
    [`& .${linearProgressClasses.bar}`]: {
      borderRadius: 5,
      backgroundColor: '#9F8069',
    },
  }));

export default LinearNoReviews;