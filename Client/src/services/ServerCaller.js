
function checkForError(response) {
	if (!response.ok) throw Error(response.statusText);
	return response;
};

export async function httpPost(url, body, onSuccess = () => { }, onFailure = () => { }) {
	function getPostRequestOptions(body) {
		return {
			method: 'POST',
			headers: { 'Content-Type': 'application/json' },
			body: JSON.stringify(body)
		};
	}

	const requestOptions = getPostRequestOptions(body);

	await callServer(url, requestOptions, onSuccess, onFailure);
}

export async function httpGet(url, params, onSuccess = () => { }, onFailure = () => { }) {

	function objToQueryString(obj) {
		const keyValuePairs = [];
		for (const key in obj) {
			keyValuePairs.push(encodeURIComponent(key) + '=' + encodeURIComponent(obj[key]));
		}
		return keyValuePairs.join('&');
	}

	function getUrlWithParams(url, params) {
		return url + (params ? `?${objToQueryString(params)}` : '');
	}

	await callServer(getUrlWithParams(url, params), onSuccess, onFailure);
}

async function callServer(url, options, onSuccess, onFailure) {
	await fetch(url, options)
		.then(async (response) => await checkForError(response))
		.then(async response => await response.json())
		.then(data => {
			console.log("data", data);
			onSuccess(data);
		})
		.catch(error => {
			console.error('Возникла проблема с вашим запросом:', error.message);
			onFailure(error);
		});
}