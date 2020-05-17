import { httpPost } from "./ServerCaller";
import { CREATE_LOT } from "../constants/ApiPaths"

export function createLot({ id, title, description, startPrice, priceStep, biddingTime },
    onSuccess, onFailure) {
    httpPost(
        CREATE_LOT,
        {
            id: id,
            title: title,
            description: description,
            startPrice: startPrice,
            priceStep: priceStep,
            biddingTime: biddingTime
        },
        onSuccess,
        onFailure
    );
}
