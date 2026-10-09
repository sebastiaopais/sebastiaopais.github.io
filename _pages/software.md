---
layout: archive
title: "Software"
permalink: /software/
author_profile: true
---

Software, datasets and online services developed by my research group, most of them as outputs of funded research projects. Source code and further details are available from each tool's page.

{% include base_path %}

{% for post in site.software reversed %}
  {% include archive-single.html %}
{% endfor %}
