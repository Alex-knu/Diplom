import {BelongingFunction} from "./models/belongingFunction.model";

export const ROLE_USER = 'User';
export const ROLE_EVALUATOR = 'Evaluator';
export const ROLE_ADMIN = 'Admin';

export const belongingFunctions = [
  {
    id: "f4bf3d51-4f18-42e5-b92f-1e8cf40dca1a",
    name: "SigmoidMembershipFunction"
  },
  {
    id: "a13bcaf8-0d49-4df7-ba32-0d6fd5b4c4c0",
    name: "GaussianMembershipFunction"
  },
  {
    id: "6d8622f5-8e17-49a9-b66e-5e11fd761278",
    name: "ExponentialMembershipFunction"
  },
  {
    id: "9c4b86fc-0f8f-4e26-8de0-29c57b076a54",
    name: "QuadraticMembershipFunction"
  }
];
